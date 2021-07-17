using CodeReader.Scripts.ViewModel;
using System.IO;
using System.Windows;

namespace CodeReader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// File extension of files which will be contain info about code components.
        /// </summary>
        public const string FILE_EXTENSION = ".cb";

        private static string filePath { get; set; } = string.Empty;

        #region View Model Instances
        public static MainVM mainVM { get; set; }
        public static ExtendedPanelVM extendedPanelVM { get; set; }
        public static ConfirmingWindowVM confirmingWindowVM { get; set; }
        #endregion

        public App()
        {
            mainVM = new MainVM() { FilePath = filePath };
            extendedPanelVM = new ExtendedPanelVM();
            confirmingWindowVM = new ConfirmingWindowVM();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (e.Args.Length > 0)
            {
                string path = e.Args[0];
                if(Path.GetExtension(path) == FILE_EXTENSION)
                    filePath = path;
            }
        }
    }
}
