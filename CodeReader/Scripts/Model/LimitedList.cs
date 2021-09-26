using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CodeReader.Scripts.Model
{
    public class LimitedList<T>:ObservableCollection<T>
    {
        public int Size { get; private set; }

        public LimitedList(int size):base()
        {
            Size = size;
            DeleteExcess();
        }

        private void DeleteExcess()
        {
            while (Count > Size)
                this.Remove(this.Last());
        }

        public new void Add(T item)
        {
            if (this.Contains(item))
                this.Remove(item);
            this.Insert(0, item);
            DeleteExcess();
        }
    }
}
