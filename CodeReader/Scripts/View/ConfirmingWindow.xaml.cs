using CodeReader.Scripts.Enums;
using CodeReader.Scripts.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CodeReader.Scripts.View
{
    /// <summary>
    /// Interaction logic for ConfirmingWindow.xaml
    /// </summary>
    public partial class ConfirmingWindow : Window
    {
        public ConfirmingWindow()
        {
            InitializeComponent();
            confirmWindGrid.DataContext = this;
        }

        public new RelationshipType ShowDialog()
        {
            base.ShowDialog();
            return RelationshipType.Aggregation;
        }

        #region Commands

        #region SelectTypeCommand
        private RelayCommand selectTypeCommand;
        public RelayCommand SelectTypeCommand
        {
            get => selectTypeCommand ?? (selectTypeCommand = new RelayCommand(obj =>
            {
                RelationshipType btnCaption =(RelationshipType) obj;
            }));
        }
        #endregion
        #endregion

    }
}
