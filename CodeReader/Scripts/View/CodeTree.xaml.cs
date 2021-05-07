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



        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Grid mainGrid = sender as Grid;
            if (firstColumn.ActualWidth < 85)
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


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            App.extendedPanelVM.CurrentComponent = codeTree.SelectedItem as CodeComponent;
        }
    }
}
