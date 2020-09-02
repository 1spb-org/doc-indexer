using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace DocIndexer
{
    public class Settings
    {
        [EditorAttribute(typeof(FolderNameEditor), typeof(UITypeEditor))]
        [Category("Base Folder")]
        public string SearchScopePath { get; set; }
        
        [Category("Filtering")]
        public string FilterText { get; set; }
        [Category("Filtering Options")]
        public bool WholeWordOnly { get; set; } = false;
        [Category("Filtering Options")]
        public bool CaseInsensitive { get; set; } = false;
    }
}
