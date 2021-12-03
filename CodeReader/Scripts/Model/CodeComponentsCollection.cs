using System.Collections.Generic;
using System.Collections.ObjectModel;
using CodeReader.Scripts.Extensions;
using CodeReader.Scripts.Interfaces;
фыфывафывафыва
namespace CodeReader.Scripts
{
    /// <summary>
    /// Class for auto realizing CollectionChanged event.
    /// </summary>
    public class CodeComponentsCollection : ObservableCollection<ICodeComponent>
    {
        public CodeComponentsCollection() : base()
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

        public new int IndexOf(ICodeComponent value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].ID == value.ID)
                    return i;
            }
            return -1;
        }

        public CodeComponentsCollection GetAllElementsWithLabel(string label, CodeComponentsCollection output = null)
        {
            if (output == null)
                output = new CodeComponentsCollection();
            foreach (var comp in this)
            {
                if (comp.Label.ContainsLabel(label))
                    output.Add(comp);
                foreach (var child in comp.Children)
                {
                    if (child.Label.ContainsLabel(label))
                        output.Add(child);
                    output.AddRange(child.Children.GetAllElementsWithLabel(label));
                }
            }
            return output;
        }


    }

    public static class LabelHelper
    {
        public static bool ContainsLabel(this string label, string str)
        {
            return label.ToLower().Contains(str.ToLower());
        }
    }
}
