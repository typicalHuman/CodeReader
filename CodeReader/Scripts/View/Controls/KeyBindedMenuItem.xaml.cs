using CodeReader.Scripts.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CodeReader.Scripts.View.Controls
{
    /// <summary>
    /// Interaction logic for KeyBindedMenuItem.xaml
    /// </summary>
    public partial class KeyBindedMenuItem : MenuItem, INotifyPropertyChanged
    {
        #region Ctor

        public KeyBindedMenuItem()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Properties


        #region MainText


        public static readonly DependencyProperty MainTextProperty =
      DependencyProperty.Register("MainText", typeof(string), typeof(KeyBindedMenuItem),
           new FrameworkPropertyMetadata(string.Empty));

        public string MainText
        {
            get => (string)GetValue(MainTextProperty);
            set
            {
                SetValue(MainTextProperty, value);
                OnPropertyChanged("MainText");
            }
        }

        #endregion

        #region TipText

        public static readonly DependencyProperty TipTextProperty =
      DependencyProperty.Register("TipText", typeof(string), typeof(KeyBindedMenuItem),
           new FrameworkPropertyMetadata(string.Empty));

        public string TipText
        {
            get => (string)GetValue(TipTextProperty);
            set
            {
                SetValue(TipTextProperty, value);
                OnPropertyChanged("TipText");
            }
        }

        #endregion

        #region MainFontSize
        public static readonly DependencyProperty MainFontSizeProperty =
      DependencyProperty.Register("MainFontSize", typeof(int), typeof(KeyBindedMenuItem),
           new FrameworkPropertyMetadata(14));

        public int MainFontSize
        {
            get => (int)GetValue(MainFontSizeProperty);
            set
            {
                SetValue(MainFontSizeProperty, value);
                OnPropertyChanged("MainFontSize");
            }
        }


        #endregion

        #region TipFontSize
        public static readonly DependencyProperty TipFontSizeProperty =
      DependencyProperty.Register("TipFontSize", typeof(int), typeof(KeyBindedMenuItem),
           new FrameworkPropertyMetadata(11));

        public int TipFontSize
        {
            get => (int)GetValue(TipFontSizeProperty);
            set
            {
                SetValue(TipFontSizeProperty, value);
                OnPropertyChanged("TipFontSize");
            }
        }

        #endregion

        #region MainForeground

        public static readonly DependencyProperty MainForegroundProperty =
      DependencyProperty.Register("MainForeground", typeof(Brush), typeof(KeyBindedMenuItem),
           new FrameworkPropertyMetadata(null));

        public Brush MainForeground
        {
            get => (Brush)GetValue(MainForegroundProperty);
            set
            {
                SetValue(MainForegroundProperty, value);
                OnPropertyChanged("MainForeground");
            }
        }

        #endregion

        #region ClickCommand
        public static readonly DependencyProperty ClickCommandProperty =
      DependencyProperty.Register("ClickCommand", typeof(RelayCommand), typeof(KeyBindedMenuItem),
           new FrameworkPropertyMetadata(null));

        public RelayCommand ClickCommand
        {
            get => (RelayCommand)GetValue(ClickCommandProperty);
            set
            {
                SetValue(ClickCommandProperty, value);
                OnPropertyChanged("ClickCommand");
            }
        }

        #endregion

        #region ContentMargin
        public static readonly DependencyProperty ContentMarginProperty =
      DependencyProperty.Register("ContentMargin", typeof(Thickness), typeof(KeyBindedMenuItem),
           new FrameworkPropertyMetadata(new Thickness(0)));

        public Thickness ContentMargin
        {
            get => (Thickness)GetValue(ContentMarginProperty);
            set
            {
                SetValue(ContentMarginProperty, value);
                OnPropertyChanged("ContentMargin");
            }
        }

        #endregion

        #endregion

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
    }
}
