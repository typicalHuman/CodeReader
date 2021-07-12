using CodeReader.Scripts.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace CodeReader.Scripts.View.Controls
{
    /// <summary>
    /// Interaction logic for KeyBindedMenuItem.xaml
    /// </summary>
    public partial class KeyBindedMenuItem : MenuItem, INotifyPropertyChanged
    {
        public KeyBindedMenuItem()
        {
            InitializeComponent();
        }

        #region PropertyChanged
        /// <summary>
        /// Event for updating value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Method to update bound value.
        /// </summary>
        /// <param name="prop">The name of property that has changed.</param>
        public virtual void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion

        #region MainText
        public static readonly DependencyProperty MainTextProperty =
      DependencyProperty.Register("MainText", typeof(string), typeof(KeyBindedMenuItem),
           new PropertyMetadata(string.Empty, OnMainTextChanged));

        public string MainText
        {
            get => (string)GetValue(MainTextProperty);
            set
            {
                SetValue(MainTextProperty, value);
                OnPropertyChanged("MainText");
            }
        }

        private static void OnMainTextChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            KeyBindedMenuItem UserControl1Control = d as KeyBindedMenuItem;
            UserControl1Control.OnMainTextChanged(e);
        }

        private void OnMainTextChanged(DependencyPropertyChangedEventArgs e)
        {
            MainText = (string)e.NewValue;
        }

        #endregion

        #region TipText
        public static readonly DependencyProperty TipTextProperty =
      DependencyProperty.Register("TipText", typeof(string), typeof(KeyBindedMenuItem),
           new PropertyMetadata(string.Empty, OnTipTextChanged));

        public string TipText
        {
            get => (string)GetValue(TipTextProperty);
            set
            {
                SetValue(TipTextProperty, value);
                OnPropertyChanged("TipText");
            }
        }

        private static void OnTipTextChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            KeyBindedMenuItem UserControl1Control = d as KeyBindedMenuItem;
            UserControl1Control.OnTipTextChanged(e);
        }

        private void OnTipTextChanged(DependencyPropertyChangedEventArgs e)
        {
            TipText = (string)e.NewValue;
        }

        #endregion

        #region MainFontSize
        public static readonly DependencyProperty MainFontSizeProperty =
      DependencyProperty.Register("MainFontSize", typeof(int), typeof(KeyBindedMenuItem),
           new PropertyMetadata(14, OnMainFontSizeChanged));

        public int MainFontSize
        {
            get => (int)GetValue(MainFontSizeProperty);
            set
            {
                SetValue(MainFontSizeProperty, value);
                OnPropertyChanged("MainFontSize");
            }
        }

        private static void OnMainFontSizeChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            KeyBindedMenuItem UserControl1Control = d as KeyBindedMenuItem;
            UserControl1Control.OnMainFontSizeChanged(e);
        }

        private void OnMainFontSizeChanged(DependencyPropertyChangedEventArgs e)
        {
            MainFontSize = (int)e.NewValue;
        }

        #endregion

        #region TipFontSize
        public static readonly DependencyProperty TipFontSizeProperty =
      DependencyProperty.Register("TipFontSize", typeof(int), typeof(KeyBindedMenuItem),
           new PropertyMetadata(11, OnTipFontSizeChanged));

        public int TipFontSize
        {
            get => (int)GetValue(TipFontSizeProperty);
            set
            {
                SetValue(TipFontSizeProperty, value);
                OnPropertyChanged("TipFontSize");
            }
        }

        private static void OnTipFontSizeChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            KeyBindedMenuItem UserControl1Control = d as KeyBindedMenuItem;
            UserControl1Control.OnTipFontSizeChanged(e);
        }

        private void OnTipFontSizeChanged(DependencyPropertyChangedEventArgs e)
        {
            TipFontSize = (int)e.NewValue;
        }

        #endregion

        #region ClickCommand
        public static readonly DependencyProperty ClickCommandProperty =
      DependencyProperty.Register("ClickCommand", typeof(RelayCommand), typeof(KeyBindedMenuItem),
           new PropertyMetadata(null, OnClickCommandChanged));

        public RelayCommand ClickCommand
        {
            get => (RelayCommand)GetValue(ClickCommandProperty);
            set
            {
                SetValue(ClickCommandProperty, value);
                OnPropertyChanged("ClickCommand");
            }
        }

        private static void OnClickCommandChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            KeyBindedMenuItem UserControl1Control = d as KeyBindedMenuItem;
            UserControl1Control.OnClickCommandChanged(e);
        }

        private void OnClickCommandChanged(DependencyPropertyChangedEventArgs e)
        {
            ClickCommand = (RelayCommand)e.NewValue;
        }

        #endregion
    }
}
