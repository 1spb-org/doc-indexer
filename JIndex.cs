using System.Collections.Generic;

namespace DocIndexer
{
    public class JIndex
    {

        public List<File> Files { get; set; }
        public List<Entry> WordsIndex { get; set; }

        public class File
        {
            public string Path { get; set; }
            public ulong Id { get; set; }
            public long Size { get; set; }
        }

        public class Item
        {
            public ulong Count { get;  set; }
            public ulong Id { get;  set; }
        }

        public class Entry
        {
            public string Key { get;  set; }
            public List<Item> Items { get;  set; }
        }

        public class Grouping
        {
            public string Word { get; set; }
            public ulong Count { get; set; }
            public ulong Id { get; set; }
            public ulong GId { get; internal set; }
        }

    }
}