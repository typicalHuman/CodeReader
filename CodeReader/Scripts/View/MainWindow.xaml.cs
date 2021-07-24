using CodeReader.Scripts.View;
using GalaSoft.MvvmLight.Messaging;
using System;
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
            App.mainVM.Navigate = Frame1.Navigate;
        }

        //private void NavigationSetup()
        //{
        //    Messenger.Default.Register<NavigateArgs>(this, (x) =>
        //    {
        //        if (!x.Url.Contains("Select"))
        //            Frame1.Navigate(new Uri(x.Url, UriKind.Relative));
        //    });
        //}
    }

}
