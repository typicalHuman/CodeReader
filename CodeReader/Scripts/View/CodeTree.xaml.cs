using CodeReader.Scripts.Model;
using CodeReader.Scripts.ViewModel;
using ModernWpf.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CodeReader.Scripts.Extensions;
using Notifications.Wpf;
using GongSolutions.Wpf.DragDrop;
using System.Collections.ObjectModel;

namespace CodeReader.Scripts.View
{
    /// <summary>
    /// Interaction logic for CodeTree.xaml
    /// </summary>
    public partial class CodeTree : UserControl, INotifyPropertyChanged
    {
        #region Enum

        /// <summary>
        /// Enum for establishing movement direction in <see cref="CodeTree"/> control.
        /// </summary>
        private enum Direction
        {
            Up = -1, Down = 1
        }

        #endregion

        #region Ctor
        public CodeTree()
        {
            InitializeComponent();
            mainGrid.DataContext = this;
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

        #region Properties

        /// <summary>
        /// Manager for showing notifications.
        /// </summary>
        private NotificationManager notificationManager { get; set; } = new NotificationManager();

        /// <summary>
        /// Item which is storing after copy or cutting operation.
        /// </summary>
        private TreeViewItem BufferComponent { get; set; }

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

        #region VisualUpwardSearch
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
        #endregion

        #region DeleteItem

        private void DeleteItem(CodeComponent cc)
        {
            if (cc.Parent == null)
            {
                CodeComponents.Remove(cc);
                UpdateExtendedPanel();
                return;
            }
            var parent = cc.Parent;
            parent.Children.Remove(cc);
            UpdateExtendedPanel();
        }
        #endregion

        #region UpdateExtendedPanel

        private void UpdateExtendedPanel()
        {
            App.extendedPanelVM.CurrentComponent = codeTree.SelectedItem as CodeComponent;
        }
        #endregion

        #region OpenItem

        private void OpenItem(object selectedItem)
        {
            App.extendedPanelVM.CurrentComponent = codeTree.SelectedItem as CodeComponent;
        }

        #endregion

        #region RenameCurrentItem

        private void RenameCurrentItem()
        {
            if (selectedItem != null)
            {
                TextBox nameTb = selectedItem.GetUIChildOfType<TextBox>();
                nameTb.Focus();
                nameTb.SelectAll();
            }
        }
        #endregion

        #region GetDefaultComponent

        private ICodeComponent GetDefaultComponent(ICodeComponent parent)
        {
            ICodeComponent newComponent = new CodeComponent() as ICodeComponent;
            newComponent.Parent = parent;
            return newComponent;
        }

        #endregion

        #region SelectComponent

        private void SelectComponent(TreeViewItem item)
        {
            item.IsSelected = true;
            OpenItem(item);
        }
        #endregion

        #region AddChild

        private void AddChild(TreeViewItem parent)
        {
            if (selectedItem == null)
            {
                ShowWarning();
                return;
            }
            ICodeComponent newComponent = GetDefaultComponent(codeTree.SelectedItem as ICodeComponent);
            AddChild(parent, newComponent);
        }

        private void AddChild(TreeViewItem parent, ICodeComponent child)
        {
            if (selectedItem == null)
                return;
            (codeTree.SelectedItem as ICodeComponent).Children.Insert(0, child);
            selectedItem.InitItemContainer();
            TreeViewItem newItem = selectedItem.ItemContainerGenerator.ContainerFromItem(child) as TreeViewItem;
            SelectComponent(newItem);
        }

        /// <summary>
        /// Show notification with warning.
        /// </summary>
        private void ShowWarning()
        {
            NotificationContent content = new NotificationContent()
            {
                Type = NotificationType.Warning,
                Title = "Warning",
                Message = "Select item at first!"
            };
            notificationManager.Show(content, "NotificationsArea");
        }

        #endregion

        #region SelectionChangeMethods

        /// <summary>
        /// Move selection in <paramref name="dir"/> direction.
        /// </summary>
        /// <param name="dir">Direction of moving.</param>
        private void MoveSelection(Direction dir)
        {
            TreeViewItem parent = selectedItem.GetRoot() as TreeViewItem;
            List<TreeViewItem> stack = GenerateStack(parent);
            int index = stack.IndexOf(selectedItem);
            if (CanMoveInSubRoot(dir, index, stack.Count))
            {
                SelectComponent(stack[index + (int)dir]);
                return;
            }
            SelectRootItem(dir, parent, selectedItem != parent);
        }
        /// <summary>
        /// Gets boolean value: can you go deeper into items, or it's last item.
        /// </summary>
        /// <param name="dir">Direction of moving.</param>
        /// <param name="index">Index of selected item.</param>
        /// <param name="stackCount">Items count of selected item parent.</param>
        private bool CanMoveInSubRoot(Direction dir, int index, int stackCount)
        {
            return (dir == Direction.Down && index + (int)dir < stackCount) ||
                (dir == Direction.Up && index + (int)dir >= 0);
        }

        /// <summary>
        /// Create stack based on parent (if it's not null) or on selected item.
        /// </summary>
        private List<TreeViewItem> GenerateStack(TreeViewItem parent)
        {
            List<TreeViewItem> stack = new List<TreeViewItem>();
            if (selectedItem.Items.Count > 0)
                stack = selectedItem.IterateTree();
            else if (parent != null)
                stack = parent.IterateTree();
            return stack;
        }

        /// <summary>
        /// Select root item 
        /// (it needs when the range with child items is over).
        /// </summary>
        /// <param name="dir">Direction of moving.</param>
        private void SelectRootItem(Direction dir, TreeViewItem parent, bool isCurrentRoot = false)
        {
            int index = CodeComponents.IndexOf(
                codeTree.ItemContainerGenerator.ItemFromContainer(parent)
                as ICodeComponent);
            if ((index == CodeComponents.Count - 1 && dir == Direction.Down) ||
                (index == 0 && dir == Direction.Up && !isCurrentRoot))
                SelectComponent(GetRootItem(GetItemsBorder(dir)));
            else if(isCurrentRoot && dir == Direction.Up)
                SelectComponent(GetRootItem(index));
            else
                SelectComponent(GetRootItem(index + (int)dir));
        }

        /// <summary>
        /// Get <see cref="TreeViewItem"/> root by it's index.
        /// </summary>
        /// <param name="index">Index of root.</param>
        private TreeViewItem GetRootItem(int index)
        {
            return codeTree.ItemContainerGenerator.ContainerFromIndex(index) as TreeViewItem;
        }
        
        /// <summary>
        /// For movement upwards the border is 0, for movement downwards the border is items count
        /// </summary>
        /// <param name="dir">Direction of movement.</param>
        private int GetItemsBorder(Direction dir)
        {
            return dir == Direction.Down ? 0 : codeTree.Items.Count - 1;
        }

        #endregion

      
        #endregion

        #region Events

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
            RenameCurrentItem();
        }

        #endregion

        #region Delete

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DeleteItem(codeTree.SelectedItem as CodeComponent);
        }

        #endregion

        #region AddChild

        private void AddChildMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddChild(selectedItem);
        }

        #endregion


        #region Copy

        private void CopyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            BufferComponent = selectedItem;
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
                controlRow.Height = new GridLength(1);
            }
            else if (mainGrid.Visibility == Visibility.Hidden)
            {
                mainGrid.Visibility = Visibility.Visible;
                controlRow.Height = new GridLength(1, GridUnitType.Auto);
            }
        }

        #endregion

        #region TreeViewItem_Selected

        /// <summary>
        /// Event for setting static instance of treeview selected item.
        /// </summary>
        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            var a = codeTree;
            selectedItem = e.OriginalSource as TreeViewItem;
            selectedItem.Focus();
        }

        #endregion

        #region MouseDoubleClick
        /// <summary>
        /// When you're clicking on subroot treeviewitem event of clicking is handled several times 
        /// (it depends on item depth) 
        /// For this reason there's an instant, which is counting number of enters in the event, 
        /// because we have functionality of hiding padding on double click 
        /// (by default padding updates after double click and I want to remove this function)
        /// </summary>
        private void TreeItemPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource.GetType() == typeof(Border)//if we are clicking on area of treeviewitem
                && (e.Source.GetType() == typeof(TreeViewItem) || e.Source.GetType() == typeof(Border))//and we are not clicking on treeviewitem ui children
                && e.ClickCount > 1)//double mouse click check
            {
                e.Handled = true;
                if (selectedItem != null)
                  OpenItem(codeTree.SelectedItem);
            }

        }
        #endregion

        #region ControlButtonsClick

        #region AddParent
        private void AddParent_Btn_Click(object sender, RoutedEventArgs e)
        {
            ICodeComponent newComponent = GetDefaultComponent(null);
            CodeComponents.Insert(0, newComponent);
            TreeViewItem newItem = codeTree.ItemContainerGenerator.ContainerFromIndex(0) as TreeViewItem;
            SelectComponent(newItem);
        }
        #endregion

        #region AddChild

        private void AddChild_Btn_Click(object sender, RoutedEventArgs e)
        {
            AddChild(selectedItem);
        }

        #endregion

        #endregion

        #endregion

        #region KeyCommands

        #region RenameCommand
        private RelayCommand renameCommand;
        public RelayCommand RenameCommand
        {
            get => renameCommand ?? (renameCommand = new RelayCommand(obj =>
            {
                RenameCurrentItem();
            }));
        }
        #endregion

        #region DeleteCommand
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get => deleteCommand ?? (deleteCommand = new RelayCommand(obj =>
            {
                CodeComponent selectedComponent = codeTree.SelectedItem as CodeComponent;
                if(selectedComponent != null)
                     DeleteItem(codeTree.SelectedItem as CodeComponent);
            }));
        }
        #endregion

        #region MoveSelectionCommands

        #region SelectNextCommand
        private RelayCommand selectNextCommand;
        public RelayCommand SelectNextCommand
        {
            get => selectNextCommand ?? (selectNextCommand = new RelayCommand(obj =>
            {
                MoveSelection(Direction.Down);
            }));
        }
        #endregion

        #region SelectPrevCommand
        private RelayCommand selectPrevCommand;
        public RelayCommand SelectPrevCommand
        {
            get => selectPrevCommand ?? (selectPrevCommand = new RelayCommand(obj =>
            {
                MoveSelection(Direction.Up);

            }));
        }
        #endregion

        #endregion

        #region AddChildCommand
        private RelayCommand addChildCommand;
        public RelayCommand AddChildCommand
        {
            get => addChildCommand ?? (addChildCommand = new RelayCommand(obj =>
            {
                AddChild(selectedItem);
            }));
        }
        #endregion


        #region CopyCommand
        private RelayCommand copyCommand;
        public RelayCommand CopyCommand
        {
            get => copyCommand ?? (copyCommand = new RelayCommand(obj =>
            {
                BufferComponent = selectedItem;
            }));
        }
        #endregion

        #region InsertCommand
        private RelayCommand insertCommand;
        public RelayCommand InsertCommand
        {
            get => insertCommand ?? (insertCommand = new RelayCommand(obj =>
            {
                ICodeComponent component;
                if(BufferComponent.Parent == null)
                    component = codeTree.ItemContainerGenerator.ItemFromContainer(BufferComponent) as ICodeComponent;
                //else
                //    component = selectedItem.
                //AddChild(selectedItem, BufferComponent);
            }));
        }
        #endregion

        #endregion
    }
}
