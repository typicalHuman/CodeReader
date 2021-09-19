using CodeReader.Scripts.View;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace CodeReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// File extension of files which will be contain info about code components.
        /// </summary>
        public const string FILE_EXTENSION = ".cb";


        public MainWindow()
        {
            InitializeComponent();
            App.mainVM.Navigate = Frame1.Navigate;
            this.Loaded += WindowLoaded;
        }

        private void WindowLoaded(object sender, EventArgs e)
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                string fileName = args[1];
                if (File.Exists(fileName))
                {
                    string extension = Path.GetExtension(fileName);
                    if (extension == FILE_EXTENSION)
                        App.mainVM.OpenFile(fileName);
                }
            }
        }

    }

}
