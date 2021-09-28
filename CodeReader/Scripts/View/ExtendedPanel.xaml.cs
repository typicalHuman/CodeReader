using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            App.extendedPanelVM.Document = cbc.Document;
        }

        private void ComboBoxItem_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            e.Handled = true;
        }

    }
}
