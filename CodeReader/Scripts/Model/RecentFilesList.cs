using System.Collections.Generic;
using System.IO;

namespace CodeReader.Scripts.Model
{
    public class RecentFilesList: LimitedList<RecentFile>
    {
        public const int RECENT_FILES_COUNT = 10;

        public RecentFilesList() : base(RECENT_FILES_COUNT) {   }

        public void CreateNewItem(string path)
        {
            RecentFile rf = new RecentFile();
            rf.Location = Path.GetDirectoryName(path);
            rf.Name = Path.GetFileNameWithoutExtension(path);
            this.Add(rf);
        }

        public void AddRange(IEnumerable<RecentFile> range)
        {
            foreach(RecentFile rf in range)
                Add(rf);
        }

        public new void Add(RecentFile item)
        {
            if (Contains(item))
                Remove(item);
            base.Add(item);
        }
    }
}
