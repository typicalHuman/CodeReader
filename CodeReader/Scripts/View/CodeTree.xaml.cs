using CodeReader.Scripts.Model;
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
            DataContext = this;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
            IsExtended = true;
        }

        #region IsExtended

        private bool isExtended = false;
        public bool IsExtended
        {
            get => isExtended;
            set
            {
                isExtended = value;
                OnPropertyChanged("IsExtended");
            }
        }

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
    }
}
