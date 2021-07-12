using System.Windows;
using System.Windows.Controls.Primitives;

namespace CodeReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event for catching window change and resizing grid columns.
        /// </summary>
        private void SplitterDragDelta(object sender, DragDeltaEventArgs e)
        {
            double newWidth = codeReaderPanel.ColumnDefinitions[0].ActualWidth + e.HorizontalChange;
            if(newWidth >= 0)
                codeReaderPanel.ColumnDefinitions[0].Width = new GridLength(newWidth);
        }
    }

}
