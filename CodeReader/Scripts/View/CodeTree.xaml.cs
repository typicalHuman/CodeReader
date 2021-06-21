using CodeReader.Scripts.Model;
using CodeReader.Scripts.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeReader.Scripts.View
{
    /// <summary>
    /// Interaction logic for CodeTree.xaml
    /// </summary>
    public partial class CodeTree : UserControl, INotifyPropertyChanged
    {
        #region Ctor

        public CodeTree()
        {
            InitializeComponent();
            
        }

        #endregion

        #region Dependency properties

        #region CodeComponents

        public static readonly DependencyProperty ItemsSourceProperty =
   DependencyProperty.Register("CodeComponents", typeof(IList<ICodeComponent>), typeof(CodeTree), new
      PropertyMetadata(new List<ICodeComponent>(), new PropertyChangedCallback(OnItemsSourceChanged)));

        public IList<ICodeComponent> CodeComponents
        {
            get { return (IList<ICodeComponent>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        private static void OnItemsSourceChanged(DependencyObject d,
     DependencyPropertyChangedEventArgs e)
        {
            CodeTree tree = d as CodeTree;
            tree.OnItemsSourceChanged(e);
        }

        private void OnItemsSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            codeTree.ItemsSource = e.NewValue as IList<ICodeComponent>;
            if (codeTree.ItemsSource == null)
                codeTree.ItemsSource = new List<ICodeComponent>();
        }

        #endregion

        #endregion

        #region PropertyChanged
        /// <summary>
        /// Event for updating value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Method to update bound value.
        /// </summary>
        /// <param name="prop">The name of property that has changed.</param>
        public virtual void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion

        #region Methods

        /// <summary>
        /// Get child in subroot of treeview.
        /// </summary>
        /// <param name="source">Root of treeview.</param>
        private static TreeViewItem VisualUpwardSearch(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);

            return source as TreeViewItem;
        }

        private void DeleteItem(CodeComponent cc)
        {
            if(cc.Parent == null)
            {
                CodeComponents.Remove(cc);
                return;
            }
            var parent = cc.Parent;
           parent.Children.Remove(cc);
        }

        private void OpenItem(object selectedItem)
        {
            App.extendedPanelVM.CurrentComponent = codeTree.SelectedItem as CodeComponent;
        }

        #endregion

        #region Event

        #region MenuEvents

        #region Open

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenItem(codeTree.SelectedItem);
        }

        #endregion

        #region Rename
        /// <summary>
        /// This instance is needed for getting subroot children of treeview.
        /// </summary>
        private static TreeViewItem selectedItem { get; set; }
        private void RenameMenuItem_Click(object sender, RoutedEventArgs e)
        {
            TextBox nameTb = selectedItem.GetChildOfType<TextBox>();
            nameTb.Focus();
            nameTb.SelectAll();
        }

        #endregion

        #region Delete

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DeleteItem(codeTree.SelectedItem as CodeComponent);
        }

        #endregion



        #endregion

        #region PreviewMouseRightButtonDown
        /// <summary>
        /// Event for selection item after right button click on it.
        /// </summary>
        private void TreeViewItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem item = VisualUpwardSearch(e.OriginalSource as DependencyObject);
            if (item != null)
            {
                item.IsSelected = true;
                e.Handled = true;
            }
        }
        #endregion

        #region GridSizeChanged
        /// <summary>
        /// Event for resizing control button with resizing of grid with gridsplitter.
        /// </summary>
        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Grid mainGrid = sender as Grid;
            if (firstColumn.ActualWidth < 75)
            {
                mainGrid.Visibility = Visibility.Hidden;
                firstRow.Height = new GridLength(1);
            }
            else if (mainGrid.Visibility == Visibility.Hidden)
            {
                mainGrid.Visibility = Visibility.Visible;
                firstRow.Height = new GridLength(1, GridUnitType.Auto);
            }
        }

        #endregion

        #region TreeViewItem_Selected

        /// <summary>
        /// Event for setting static instance of treeview selected item.
        /// </summary>
        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            selectedItem = e.OriginalSource as TreeViewItem;
        }






        #endregion

        #endregion
        private int childrenCount { get; set; }
        private void PrevTreeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            childrenCount++;
        }

        private void TreeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (selectedItem != null)
            {
                OpenItem(codeTree.SelectedItem);
                childrenCount--;
                if (childrenCount == 0)
                {
                    var a = VisualUpwardSearch(selectedItem);
                    a.IsExpanded = !a.IsExpanded;
                }
            }
        }

        private void NameBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            childrenCount = 0;
        }
    }

    #region FindChildExtension
    /// <summary>
    /// Extension class for finding ui children of element.
    /// </summary>
    public static class FindChildExtension
    {

        /// <summary>
        /// Get ui child of <paramref name="depObj"/> by child type.
        /// </summary>
        public static T GetChildOfType<T>(this DependencyObject depObj)
             where T : DependencyObject
        {
            if (depObj == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }
    }

    #endregion


}
