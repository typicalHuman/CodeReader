using CodeReader.Scripts.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace CodeReader.Scripts.Extensions
{
    public static class CodeTreeExtension
    {
        /// <summary>
        /// Update parent-children relationships.
        /// </summary>
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

        public static ICodeComponent GetItemValue(this TreeViewItem item, ItemContainerGenerator mainGenerator)
        {
            TreeViewItem parent = item.GetParent();
            if (parent == null)
                return mainGenerator.ItemFromContainer(item) as ICodeComponent;
            else
                return parent.ItemContainerGenerator.ItemFromContainer(item) as ICodeComponent;
        }

        #endregion

    }
}
