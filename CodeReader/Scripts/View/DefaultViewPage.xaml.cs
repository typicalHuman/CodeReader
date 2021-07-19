using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CodeReader.Scripts.View
{
    /// <summary>
    /// Interaction logic for DefaultViewPage.xaml
    /// </summary>
    public partial class DefaultViewPage : Page
    {
        public DefaultViewPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event for catching window change and resizing grid columns.
        /// </summary>
        private void SplitterDragDelta(object sender, DragDeltaEventArgs e)
        {
            double newWidth = codeReaderPanel.ColumnDefinitions[0].ActualWidth + e.HorizontalChange;
            if (newWidth >= 0)
                codeReaderPanel.ColumnDefinitions[0].Width = new GridLength(newWidth);
        }
    }
}
