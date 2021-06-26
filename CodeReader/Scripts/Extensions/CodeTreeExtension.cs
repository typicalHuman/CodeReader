using CodeReader.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReader.Scripts.Extensions
{
    public static class CodeTreeExtension
    {
        public static void UpdateItems(this ObservableCollection<ICodeComponent> components)
        {
            UpdateHierarchicalRelationships(components);
        }

        #region UpdateHierarchicalRelationships

        private static void UpdateHierarchicalRelationships(ObservableCollection<ICodeComponent> components)
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Parent = null;
                UpdateItem(components[i]);
            }
        }

        private static void UpdateItem(ICodeComponent parent)
        {
            foreach (ICodeComponent component in parent.Children)
            {
                component.Parent = parent;
                if (!parent.Children.Contains(component))
                    parent.Children.Add(component);
                if (component.Children.Count > 0)
                    UpdateItem(component);
            }
        }

        #endregion

    }
}
