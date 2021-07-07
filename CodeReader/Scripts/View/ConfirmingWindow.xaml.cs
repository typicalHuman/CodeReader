using CodeReader.Scripts.Enums;
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
        }

        public new RelationshipType ShowDialog()
        {
            return RelationshipType.Aggregation;
        }

        
    }
}
