using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;


namespace DocIndexer
{
    public partial class FMain : Form
    {
        private JIndex _Index;


        private string CurrDir => Directory.GetCurrentDirectory();
        private string AppDir => Path.Combine(CurrDir, ".g-doc-indexer");
        private string CfgPath => Path.Combine(AppDir, "config.json");
        private string IndexPath => Path.Combine(AppDir, "index.json");

        public Settings Config { get; private set; }

        public FMain( /*string [] args */)
        {
            InitializeComponent();

        }

        private void FMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(AppDir))
                    Directory.CreateDirectory(AppDir);
            }
            catch 
            {
                MessageBox.Show("Could not create the index directory");
            }

            LoadConfig();

            if (File.Exists(IndexPath))
               Task.Run(() => LoadIndex());
            else
            {
                if(string.IsNullOrWhiteSpace(Config.SearchScopePath))
                {
                    Config.SearchScopePath = Directory.GetCurrentDirectory();
                }                 

                CreateIndex();
            }


        }

        private void CreateIndex()
        {
            GC.Collect();
            
            Task.Run(() =>
            {
                JProgressSet(1, "Enumerating files...");

                var Idx = DirSearch(Config.SearchScopePath);

                JProgressSet(3, "Indexing files...");

                ulong fid = 0;
                _Index = new JIndex();
                _Index.Files = Idx.Select(x => new JIndex.File { Path = x, Id = fid++, Size = new FileInfo(x).Length}).ToList();
                _TotalSize = _Index.Files.Sum(x => x.Size);
                _DateStart = DateTime.Now;
                _Velocity = 0.0;
                
                JProgressSet(5, "Extracting and counting words...");
                _gid = 0;

                var wordGrouping = new List<JIndex.Grouping>();
                _Index.Files.ForEach( x => wordGrouping.AddRange (   GetAllWords(x) ));
                                
                 
                 

                JProgressSet(50, $"Grouping by words...");

                var finalGrouping = wordGrouping.GroupBy(g => g.Word);


                var wordIndex = new List<JIndex.Entry>();

                JProgressSet(50, $"Counting groups...");
                int qG = finalGrouping.Count();



                double i = 0, kf = 40.0 /  qG;


                JProgressSet(50, $"Groups: {qG}. Indexing words...");

                DateTime wc = DateTime.Now;

                foreach(var q in finalGrouping)
                {
                    int y = (int)(50 + kf * i);
                    JProgressSet(y, $"Indexing entry: #{i}");
                    wordIndex.Add(
                        new JIndex.Entry { Key = q.Key,
                            Items = q.Select(p => new JIndex.Item { Id = p.Id, Count = p.Count }).ToList() });
                    i++;
                } 
                
                JProgressSet(90, "Saving ...");

                _Index.WordsIndex = wordIndex;

                SaveIndex();
                JProgressSet(100, "Done.");
            });
        }

     

        private void JProgressSet(int v, string msg)
        {
            Invoke(new Action(() => progressBar1.Value = v));
            Invoke(new Action(() => tsStatusMessage.Text = $"{v}% {msg}"));
        }

        SHA256Managed _sha = new SHA256Managed();
        private ulong _gid;
        private long _TotalSize;
        private DateTime _DateStart;
        private double _Velocity;
        private long _CurrentSize = 0;
        private bool _searching = false;

        /*
        private string Hash(string s)
        {
            var g = _sha.ComputeHash(Encoding.UTF8.GetBytes(s));
            return string.Join("", g.Select(z => z.ToString("x2")));
        }*/

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }

        private void LoadConfig()
        {
            try
            {
                Config = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(CfgPath));
            }
            catch
            {
                Config = new Settings();
                SaveConfig();
            }

            propertyGrid1.SelectedObject = Config;
            txFilter.Text = Config.FilterText?.Trim();
        }

        private void LoadIndex()
        {
            JProgressSet(0, "Loading Index...");
            try
            {
                var f = File.ReadAllText(IndexPath);
                JProgressSet(50, "Parsing Index...");
                _Index = JsonConvert.DeserializeObject<JIndex>(f);
            }
            catch
            {
                JProgressSet(0, "Error while loading index!");
                _Index = new JIndex();
            }

            JProgressSet(100, "Done.");

        }


        private void SaveConfig()
        {

            Config.FilterText = txFilter.Text.Trim();
            try
            {
                File.WriteAllText(CfgPath, JsonConvert.SerializeObject(Config, Formatting.Indented));
            }
            catch
            {
            }

        }

        private void SaveIndex()
        {

            try
            {
                File.WriteAllText(IndexPath, JsonConvert.SerializeObject(_Index));
            }
            catch
            {
            }

        }

        public static List<string> DirSearch(string sDir)
        {
           return Directory.GetFiles(sDir, "*.pdf", SearchOption.AllDirectories).ToList();
          
        }

        public List<JIndex.Grouping> GetAllWords(JIndex.File x) //, string phraseToFind = "")
        {
            List<JIndex.Grouping> L = new List<JIndex.Grouping>();
            try
            {
                using (PdfDocument document = PdfDocument.Open(x.Path))
                {
                    Dictionary<string, ulong> D = new Dictionary<string, ulong>();

                    double perc = (100.0 * _CurrentSize) / _TotalSize;

                    var tsEL = DateTime.Now - _DateStart;
                    double secs = tsEL.TotalSeconds;
                    int estimated;

                    _Velocity = _CurrentSize / secs;
                    estimated = (int)(_TotalSize / _Velocity);
                    tsEL = TimeSpan.FromSeconds((int)secs);
                    var tsES = TimeSpan.FromSeconds(estimated);
                    var P = (int) ( perc * 0.45 + 5 );

                    JProgressSet(P, $"[{perc.ToString("F1", CultureInfo.InvariantCulture)}%] EL {tsEL} ES {tsES}"
                        + $"   Processing file {x.Id} of {_Index.Files.Count}: {Path.GetFileName(x.Path)} ");

                    DateTime wc = DateTime.Now;

                    try
                    {
                        foreach (Page page in document.GetPages())
                        {
                            // string pageText = page.Text;
                            foreach (Word word in page.GetWords())
                            {
                                if (D.ContainsKey(word.Text))
                                    D[word.Text]++;
                                else
                                    D[word.Text] = 0;
                                // TODO: queue words to find phrases - move it outside this code.

                                if (DateTime.Now > wc)
                                {
                                    perc = (100.0 * _CurrentSize) / _TotalSize;

                                    tsEL = DateTime.Now - _DateStart;
                                    secs = tsEL.TotalSeconds;
                                    
                                    _Velocity = _CurrentSize / secs;
                                    estimated = (int)(_TotalSize / _Velocity);
                                    tsEL = TimeSpan.FromSeconds((int)secs);
                                    tsES = TimeSpan.FromSeconds(estimated);     
                                    P = (int) ( perc * 0.45 + 5 );
                                    JProgressSet(P, $"[{perc.ToString("F1", CultureInfo.InvariantCulture)}%] EL {tsEL} ES {tsES}"
                                        + $"   Processing file {x.Id} of {_Index.Files.Count}: {Path.GetFileName(x.Path)} ");
                                    wc = DateTime.Now.AddMilliseconds(200);
                                }

                            }
                        }
                    }
                    catch { }

                    _CurrentSize += x.Size;


                   // JProgressSet(P, $"Collecting file words: {x.Id} Words: {D.Count} {Path.GetFileName(x.Path)}");

                    foreach (var kv in D)
                        L.Add(new JIndex.Grouping { GId = _gid++, Count = kv.Value, Id = x.Id, Word = kv.Key });
                    D.Clear();
                }
            }
            catch 
            { }

            return L;
        }

        private void btFilter_Click(object sender, EventArgs e)
        {

            var g = txFilter.Text.Trim();
            Config.FilterText = g;
            Filter(g);
        }

        private void Filter(string g)
        {
            lvIndex.Items.Clear();
            if (g.Length > 0)
            {
                if (_searching)
                    return;
               Task.Run(() => Search(g));

                return;
            }

            JProgressSet(0, "Listing all files");
            lvIndex.Items.AddRange(_Index.Files.Select(x => LvCreate(x) ) .ToArray());
            JProgressSet(100, "Listing all files done.");
        }

        private void Search(string g)
        {
            Invoke(new Action(() => _searching = true));
                JProgressSet(0, "Applying filter");
            Thread.Sleep(100);
                var fileIds = FilterWord(g);

                JProgressSet(25, "Flattening"); Thread.Sleep(100);

            var flattened = fileIds
                    .SelectMany(f => f.Items);

                JProgressSet(50, "Extracting keys"); Thread.Sleep(100);

            var grouped = flattened
                    .GroupBy(i => i.Id)
                    .Select(b => b.Key);

                JProgressSet(75, "Searching applicable files"); Thread.Sleep(100);

                var files = grouped.Select(x => _Index.Files.Where(w => w.Id == x).FirstOrDefault());

                Invoke(new Action(() => {
                    lvIndex.Items.AddRange(files.Select(x => LvCreate(x)).ToArray());
                }));
                JProgressSet(100, "Search done");

            Invoke(new Action(() => _searching = false));

        }

        private IEnumerable<JIndex.Entry> FilterWord(string g)
        { 
            if (Config.WholeWordOnly)
              return (Config.CaseInsensitive) ? 
                    _Index.WordsIndex.Where(x => x.Key.ToUpper() == g.ToUpper() ) :
                    _Index.WordsIndex.Where(x => x.Key == g);
            
            return (Config.CaseInsensitive) ? 
                    _Index.WordsIndex.Where(x => x.Key.ToUpper().Contains(g.ToUpper())) :
                    _Index.WordsIndex.Where(x => x.Key.Contains(g));
        }

        private ListViewItem LvCreate(JIndex.File x)
        {
            var lv = new ListViewItem { Text = Path.GetFileName(x.Path), Tag = x };
            lv.SubItems.Add(new ListViewItem.ListViewSubItem { Text = Directory.GetParent(x.Path).Name });
            lv.SubItems.Add(new ListViewItem.ListViewSubItem { Text = x.Path });
            lv.SubItems.Add(new ListViewItem.ListViewSubItem { Text = x.Id.ToString() });
            return lv;
        }

        private void lvIndex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvIndex_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem i in   lvIndex.SelectedItems)
            {
                Process.Start((i.Tag as JIndex.File).Path);
            }

        }

        private void reindexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != MessageBox.Show("Reindex?", Text, MessageBoxButtons.OKCancel))
                return;

            File.Delete(IndexPath);

            _Index?.Files?.Clear();
            _Index?.WordsIndex?.Clear();

            CreateIndex();

        }

        private void visit1spborgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://1spb.org/?src=g-doc-indexer");
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/1spb-org/doc-indexer");
        }
    }
}
