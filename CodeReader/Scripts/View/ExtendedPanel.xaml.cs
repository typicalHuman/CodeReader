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
            DataContext = this;
        }

        #region CodeComponents

        public static readonly DependencyProperty CodeComponentProperty =
   DependencyProperty.Register("OpenedCodeComponent", typeof(ICodeComponent), typeof(ExtendedPanel), new
      PropertyMetadata(new CodeComponent(), new PropertyChangedCallback(OnCodeComponentChanged)));

        public ICodeComponent OpenedCodeComponent
        {
            get { return (ICodeComponent)GetValue(CodeComponentProperty); }
            set { SetValue(CodeComponentProperty, value); }
        }

        private static void OnCodeComponentChanged(DependencyObject d,
     DependencyPropertyChangedEventArgs e)
        {
            ExtendedPanel panel = d as ExtendedPanel;
            panel.OnCodeComponentChanged(e);
        }

        private void OnCodeComponentChanged(DependencyPropertyChangedEventArgs e)
        {
            OpenedCodeComponent = e.NewValue as ICodeComponent;
        }

        #endregion


        

    }
}
