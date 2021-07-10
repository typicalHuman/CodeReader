using CodeReader.Scripts.Interfaces;
using CodeReader.Scripts.ViewModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CodeReader.Scripts.Extensions;
using Notifications.Wpf;
using GongSolutions.Wpf.DragDrop;
using CodeReader.Scripts.Enums;

namespace CodeReader.Scripts.View
{
    /// <summary>
    /// Interaction logic for CodeTree.xaml
    /// </summary>
    public partial class CodeTree : UserControl, INotifyPropertyChanged, IDropTarget
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

        #region Ctors
        public CodeTree()
        {
            InitializeComponent();
            mainGrid.DataContext = this;
        }

        static CodeTree()
        {
            defaultDropHandler = new DefaultDropHandler();
        }

        #endregion

        #region Dependency properties

        #region CodeComponents

        public static readonly DependencyProperty ItemsSourceProperty =
   DependencyProperty.Register("CodeComponents", typeof(CodeComponentsCollection), typeof(CodeTree), new
      PropertyMetadata(new CodeComponentsCollection(), new PropertyChangedCallback(OnItemsSourceChanged)));

        public CodeComponentsCollection CodeComponents
        {
            get { return (CodeComponentsCollection)GetValue(ItemsSourceProperty); }
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

        #region TargetComponent
        public static readonly DependencyProperty TargetComponentProperty =
      DependencyProperty.Register("TargetComponent", typeof(ICodeComponent), typeof(CodeTree),
          new FrameworkPropertyMetadata
          {
              DefaultValue = default(ICodeComponent),
              BindsTwoWayByDefault = true,
              PropertyChangedCallback = OnTargetComponentChanged

          });

        public ICodeComponent TargetComponent
        {
            get => (ICodeComponent)GetValue(TargetComponentProperty);
            set
            {
                SetValue(TargetComponentProperty, value);
                OnPropertyChanged("TargetComponent");
            }
        }

        private static void OnTargetComponentChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            CodeTree UserControl1Control = d as CodeTree;
            UserControl1Control.OnTargetComponentChanged(e);
        }

        private void OnTargetComponentChanged(DependencyPropertyChangedEventArgs e)
        {
                ICodeComponent newValue = e.NewValue as ICodeComponent;
                if (e.NewValue != codeTree.SelectedItem && e.NewValue != null)
                {
                    openedItem.InitItemContainer();
                    (openedItem.ItemContainerGenerator.ContainerFromItem(newValue) as TreeViewItem).IsSelected = true;
                    OpenSelectedItem();
                }
        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Item which is storing after copy or cutting operation.
        /// </summary>
        private ICodeComponent BufferComponent { get; set; }

        /// <summary>
        /// This instance is needed for getting subroot children of treeview.
        /// </summary>
        private static TreeViewItem selectedItem { get; set; }


        /// <summary>
        /// Open which is opened in extended panel.
        /// </summary>
        private static TreeViewItem openedItem { get; set; }

        /// <summary>
        /// For executing default drag and drop functionality.
        /// </summary>
        private static DefaultDropHandler defaultDropHandler { get; set; }

        /// <summary>
        /// Main participant of relationships.
        /// </summary>
        private static ICodeComponent MainParticipant { get; set; }

        /// <summary>
        /// Second participant of relationships.
        /// </summary>
        private static ICodeComponent DependentParticipant { get; set; }

        #region Notifications

        private static NotificationContent EmptyParentWarning { get; set; } = new NotificationContent()
        {
            Type = NotificationType.Warning,
            Title = "Warning",
            Message = "Select an item at first!"
        };

        private static NotificationContent RootDeletionWarning { get; set; } = new NotificationContent()
        {
            Type = NotificationType.Warning,
            Title = "Warning",
            Message = "You can't delete the main root."
        };

        private static NotificationContent SameRelationshipElementsError { get; set; } = new NotificationContent()
        {
            Type = NotificationType.Error,
            Title = "Error",
            Message = "You can't select the same element."
        };

        private static NotificationContent OnRelationshipCreating { get; set;  } = new NotificationContent()
        {
            Type = NotificationType.Information,
            Message = "Open component in the tree for creating a relationship or press ESC to cancel.",
            Title = "Information"
        };

        private static NotificationContent OnRelationshipCancel { get; set; } = new NotificationContent()
        {
            Type = NotificationType.Warning,
            Message = "Creation was canceled.",
            Title = "Information"
        };

        private static NotificationContent OnRelationshipCreated { get; set; } = new NotificationContent()
        {
            Type = NotificationType.Success,
            Message = "Relationship was created.",
            Title = "Success"
        };
        #endregion

        /// <summary>
        /// Window for setting relationship type.
        /// </summary>
        private static ConfirmingWindow confirmWindow { get; set; }

        #region IsSingleRootOpen

        private bool isSingleRootOpen;
        /// <summary>
        /// Checks is single root opened or it's tree with all items.
        /// </summary>
        public bool IsSingleRootOpen
        {
            get => isSingleRootOpen;
            set
            {
                isSingleRootOpen = value;
                OnPropertyChanged("IsSingleRootOpen");
            }
        }

        #endregion
       
        #region IsDefaultState

        private bool isDefaultState = true;
        /// <summary>
        /// Default state - view with opprotunity to edit items.
        /// Another state is when you are choosing an item for creating new relationship.
        /// </summary>
        public bool IsDefaultState
        {
            get => isDefaultState;
            set
            {
                isDefaultState = value;
                OnPropertyChanged("IsDefaultState");
            }
        }

        #endregion

        private HistoryStack History { get; set; } = new HistoryStack();

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

        private void DeleteItem(ICodeComponent cc)
        {
            if (cc.Parent == null)
            {
                if(IsSingleRootOpen)
                {
                    NotificationsManager.ShowNotificaton(RootDeletionWarning);
                    return;
                }
                History.Push(OperationType.Delete, cc, CodeComponents);
                CodeComponents.Remove(cc);
                UpdateExtendedPanel();
                return;
            }
            var parent = cc.Parent;
            History.Push(OperationType.Delete, cc, parent.Children);
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

        #region OpenSelectedItem
        /// <summary>
        /// Open TreeViewItem value in Extended Panel.
        /// </summary>
        private void OpenSelectedItem()
        {
            if (IsDefaultState)
            {
                openedItem = selectedItem;
                App.extendedPanelVM.CurrentComponent = codeTree.SelectedItem as CodeComponent;
            }
            else
            {
                if (codeTree.SelectedItem == MainParticipant)
                    NotificationsManager.ShowNotificaton(SameRelationshipElementsError);
                else
                {
                    SelectDependentParticipant();
                    IsDefaultState = true;
                    NotificationsManager.ShowNotificaton(OnRelationshipCreated);
                }
            }
        }

        private void SelectDependentParticipant()
        {
            DependentParticipant = codeTree.SelectedItem as ICodeComponent;
            confirmWindow = new ConfirmingWindow();
            RelationshipType type = confirmWindow.ShowDialog();
            Relationship.CreateRelationship(MainParticipant, DependentParticipant, type);
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
            OpenSelectedItem();
        }
        #endregion

        #region AddChild

        private void AddChild(TreeViewItem parent)
        {
            if (selectedItem == null)
            {
                NotificationsManager.ShowNotificaton(EmptyParentWarning);
                return;
            }
            ICodeComponent newComponent = GetDefaultComponent(codeTree.SelectedItem as ICodeComponent);
            AddChildToSelectedItem(newComponent);
        }

        private void AddChildToSelectedItem(ICodeComponent child)
        {
            if (selectedItem == null)
                return;
            (codeTree.SelectedItem as ICodeComponent).Children.Insert(0, child);
            selectedItem.InitItemContainer();
            TreeViewItem newItem = selectedItem.ItemContainerGenerator.ContainerFromItem(child) as TreeViewItem;
            SelectComponent(newItem);
            History.Push(OperationType.Add, child, child.Parent.Children);
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
            List<TreeViewItem> stack = GenerateStack(parent, dir);
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
        private List<TreeViewItem> GenerateStack(TreeViewItem parent, Direction dir)
        {
            List<TreeViewItem> stack = new List<TreeViewItem>();
            if (selectedItem.Items.Count > 0 && dir == Direction.Down)
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
            OpenSelectedItem();
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
                  OpenSelectedItem();
            }

        }
        #endregion

        #region ControlButtonsClick

        #region AddParent
        private void AddParent_Btn_Click(object sender, RoutedEventArgs e)
        {
            ICodeComponent newComponent = GetDefaultComponent(null);
            CodeComponents.Insert(0, newComponent);
            History.Push(OperationType.Add, newComponent, CodeComponents);
            TreeViewItem newItem = codeTree.ItemContainerGenerator.ContainerFromIndex(0) as TreeViewItem;
            SelectComponent(newItem);
        }
        #endregion

        #endregion

        #region IDropTarget Implementation

        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            ICodeComponent sourceItem = dropInfo.Data as ICodeComponent;
            ICodeComponent targetItem = dropInfo.TargetItem as ICodeComponent;
            if (targetItem != null && targetItem != sourceItem &&
                ((IsSingleRootOpen && targetItem.Parent != null) ||//is target item is root or not
                !IsSingleRootOpen))
                defaultDropHandler.DragOver(dropInfo);
        }

        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            ICodeComponent sourceItem = dropInfo.Data as ICodeComponent;
            ICodeComponent targetItem = dropInfo.TargetItem as ICodeComponent;
            CodeComponentsCollection neighbors  = targetItem.Children;
            if (targetItem.Parent == null && dropInfo.InsertPosition != RelativeInsertPosition.TargetItemCenter)
                 neighbors = CodeComponents;
            int index = CodeComponents.IndexOf(sourceItem);
            if (sourceItem.Parent != null)
                index = sourceItem.Parent.Children.IndexOf(sourceItem);
            Operation op = new Operation(OperationType.Drag, (sourceItem as CodeComponent).GetCopy(), neighbors, index);
            History.Push(op);
            defaultDropHandler.Drop(dropInfo);
        }

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
                if (IsDefaultState)
                {
                    CodeComponent selectedComponent = codeTree.SelectedItem as CodeComponent;
                    if (selectedComponent != null)
                        DeleteItem(codeTree.SelectedItem as CodeComponent);
                }
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
                if (IsDefaultState)
                {
                    AddChild(selectedItem);
                }
            }));
        }
        #endregion


        #region CopyCommand
        private RelayCommand copyCommand;
        public RelayCommand CopyCommand
        {
            get => copyCommand ?? (copyCommand = new RelayCommand(obj =>
            {
                if (IsDefaultState)
                {
                    ICodeComponent selectedComponent = selectedItem.GetItemValue(codeTree.ItemContainerGenerator);
                    BufferComponent = CodeComponent.Create(selectedComponent);
                }
            }));
        }
        #endregion

        #region CutCommand
        private RelayCommand cutCommand;
        public RelayCommand CutCommand
        {
            get => cutCommand ?? (cutCommand = new RelayCommand(obj =>
            {
                if (IsDefaultState)
                {
                    ICodeComponent selectedComponent = selectedItem.GetItemValue(codeTree.ItemContainerGenerator);
                    DeleteItem(selectedComponent);
                    BufferComponent = CodeComponent.Create(selectedComponent);
                }
            }));
        }
        #endregion

        #region PasteCommand
        private RelayCommand pasteCommand;
        public RelayCommand PasteCommand
        {
            get => pasteCommand ?? (pasteCommand = new RelayCommand(obj =>
            {
                if (IsDefaultState && BufferComponent != null)
                    AddChildToSelectedItem(BufferComponent);
            }));
        }
        #endregion

        #region OpenAsRootCommand
        private RelayCommand openAsRootCommand;
        public RelayCommand OpenAsRootCommand
        {
            get => openAsRootCommand ?? (openAsRootCommand = new RelayCommand(obj =>
            {
                if (IsDefaultState)
                {
                    ICodeComponent root = selectedItem.GetItemValue(codeTree.ItemContainerGenerator);
                    codeTree.ItemsSource = new List<ICodeComponent>() { root };
                    IsSingleRootOpen = true;
                    OpenSelectedItem();
                }
            }));
        }

        #endregion

        #region BackCommand
        private RelayCommand backCommand;
        public RelayCommand BackCommand
        {
            get => backCommand ?? (backCommand = new RelayCommand(obj =>
            {
                IsSingleRootOpen = false;
                codeTree.ItemsSource = App.mainVM.CodeComponents;
            }));
        }

        #endregion


        #region UpdateRelationshipCommand
        private RelayCommand updateRelationshipCommand;
        public RelayCommand UpdateRelationshipCommand
        {
            get => updateRelationshipCommand ?? (updateRelationshipCommand = new RelayCommand(obj =>
            {
                if (IsDefaultState)
                {
                    NotificationsManager.ShowNotificaton(OnRelationshipCreating);
                    MainParticipant = codeTree.SelectedItem as ICodeComponent;
                    IsDefaultState = false;
                    App.extendedPanelVM.CurrentComponent = null;
                }
                else
                    CancelRelationshipModeCommand.Execute(null);
            }));
        }

        #endregion

        #region CancelRelationshipModeCommand
        private RelayCommand cancelRelationshipModeCommand;
        public RelayCommand CancelRelationshipModeCommand
        {
            get => cancelRelationshipModeCommand ?? (cancelRelationshipModeCommand = new RelayCommand(obj =>
            {
                IsDefaultState = true;
                NotificationsManager.ShowNotificaton(OnRelationshipCancel);
            }));
        }

        #endregion

        #region Global Operations

        #region Undo

        private RelayCommand undoCommand;
        public RelayCommand UndoCommand
        {
            get => undoCommand ?? (undoCommand = new RelayCommand(obj =>
            {
                History.Undo();
            }));
        }

        #endregion


        #region Redo

        private RelayCommand redoCommand;
        public RelayCommand RedoCommand
        {
            get => redoCommand ?? (redoCommand = new RelayCommand(obj =>
            {
                History.Redo();
            }));
        }

        #endregion





        #endregion

        #endregion
    }
}
