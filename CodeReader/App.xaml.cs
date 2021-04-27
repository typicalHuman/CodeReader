using CodeReader.Scripts.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CodeReader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainVM mainVM { get; set; }
        public static CodeTreeVM codeTreeVM { get; set; }
        public App()
        {
            mainVM = new MainVM();
            codeTreeVM = new CodeTreeVM();
        }
    }
}
