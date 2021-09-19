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


        #region View Model Instances
        public static MainVM mainVM { get; set; }
        public static ExtendedPanelVM extendedPanelVM { get; set; }
        public static ConfirmingWindowVM confirmingWindowVM { get; set; }
        #endregion

        public App()
        {
            mainVM = new MainVM();
            extendedPanelVM = new ExtendedPanelVM();
            confirmingWindowVM = new ConfirmingWindowVM();
        }
    }
}
