namespace CodeReader.Scripts.Model
{
    public class RecentFilesList: LimitedList<RecentFile>
    {
        public RecentFilesList(int size) : base(size) { }

        public new bool Contains(RecentFile file)
        {
            foreach (RecentFile _file in this)
                if (_file.GetPath() == file.GetPath())
                    return true;
            return false;
        }
    }
}
