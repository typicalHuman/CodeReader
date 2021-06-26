using CodeReader.Scripts.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CodeReader.Scripts.Extensions
{
    #region FindChildExtension
    /// <summary>
    /// Extension class for finding ui children of element.
    /// </summary>
    public static class TreeViewExtension
    {
        /// <summary>
        /// Get ui child of <paramref name="depObj"/> by child type.
        /// </summary>
        public static T GetUIChildOfType<T>(this DependencyObject depObj)
             where T : DependencyObject
        {
            if (depObj == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetUIChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }

        /// <summary>
        /// Initcontainer for searching items in <see cref="ItemContainerGenerator"/>.
        /// </summary>
        public static void InitItemContainer(this TreeViewItem parent)
        {
            parent.IsExpanded = true;
            parent.UpdateLayout();
        }

        /// <summary>
        /// Get list with all children of parent.
        /// </summary>
        public static List<TreeViewItem> IterateTree(this TreeViewItem parent)
        {
            List<TreeViewItem> list = new List<TreeViewItem>();
            parent.InitItemContainer();
            foreach (CodeComponent item in parent.Items)
            {
                list.Add(parent.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem);
                if (item.Children.Count > 0)
                    list.AddRange(list.Last().IterateTree());
            }
            return list;
        }

        /// <summary>
        /// Get root of treeview by stepping from child to parent.
        /// </summary>
        public static TreeViewItem GetRoot(this TreeViewItem child)
        {
            DependencyObject tempObj = VisualTreeHelper.GetParent(child as DependencyObject);
            while ((tempObj as TreeViewItem) == null)
            {
                tempObj = VisualTreeHelper.GetParent(tempObj);
                if(tempObj == null)
                     return child;
            }
            if(tempObj != null)
                  return (tempObj as TreeViewItem).GetRoot();
            return null;
        }
    }

    #endregion
}
