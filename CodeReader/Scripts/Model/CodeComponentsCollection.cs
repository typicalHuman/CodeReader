using System.Collections.Generic;
using System.Collections.ObjectModel;
using CodeReader.Scripts.Extensions;

namespace CodeReader.Scripts.Model
{
    /// <summary>
    /// Class for auto realizing CollectionChanged event.
    /// </summary>
    public class CodeComponentsCollection: ObservableCollection<ICodeComponent>
    {
        public CodeComponentsCollection():base()
        {
            CollectionChanged += (sender, e) =>
            {
                if (App.mainVM != null)
                    App.mainVM.CodeComponents.UpdateItems();
            };
        }

        public void AddRange(IEnumerable<ICodeComponent> components)
        {
            foreach (ICodeComponent comp in components)
                Add(comp);
        }
    }
}
