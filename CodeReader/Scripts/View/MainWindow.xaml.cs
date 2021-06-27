using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfAnimatedGif;

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
            Splitter.DragDelta += SplitterDragDelta;
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

        private void TitleGifImage_AnimationLoaded(object sender, RoutedEventArgs e)
        {
            App.mainVM.AnimationController = ImageBehavior.GetAnimationController(TitleGifImage);
        }
    }

}
