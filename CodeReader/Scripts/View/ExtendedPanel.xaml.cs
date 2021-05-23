
using CodeReader.Scripts.Model;
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
using System.Windows.Navigation;
using CodeBox.Enums;
using System.Windows.Shapes;

namespace CodeReader.Scripts.View
{
    /// <summary>
    /// Interaction logic for ExtendedPanel.xaml
    /// </summary>
    public partial class ExtendedPanel : UserControl
    {
        public ExtendedPanel()
        {
            InitializeComponent();

        }

        private void ComboBoxItem_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            spv.IsPaneOpen = !spv.IsPaneOpen;
        }
    }
}
