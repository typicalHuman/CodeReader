using CodeReader.Scripts.Enums;
using CodeReader.Scripts.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace CodeReader.Scripts.View.Controls
{
    /// <summary>
    /// Interaction logic for RelationshipButton.xaml
    /// </summary>
    public partial class RelationshipButton : UserControl, INotifyPropertyChanged
    {
        #region Ctor

        public RelationshipButton()
        {
            InitializeComponent();
            var a = DataContext;
        }

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

        #region Dependency Properties

        #region RelationshipType
        public static readonly DependencyProperty RelationshipTypeProperty =
      DependencyProperty.Register("RelationshipType", typeof(RelationshipType), typeof(RelationshipButton),
          new FrameworkPropertyMetadata
          {
              DefaultValue = default(RelationshipType),
              BindsTwoWayByDefault = true,
              PropertyChangedCallback = OnRelationshipTypeChanged

          });

        public RelationshipType RelationshipType
        {
            get => (RelationshipType)GetValue(RelationshipTypeProperty);
            set
            {
                SetValue(RelationshipTypeProperty, value);
                OnPropertyChanged("RelationshipType");
            }
        }

        private static void OnRelationshipTypeChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            RelationshipButton UserControl1Control = d as RelationshipButton;
            UserControl1Control.OnRelationshipTypeChanged(e);
        }

        private void OnRelationshipTypeChanged(DependencyPropertyChangedEventArgs e)
        {
            RelationshipType = (RelationshipType)e.NewValue;
        }

        #endregion

        #region ClickCommand
        public static readonly DependencyProperty ClickCommandProperty =
      DependencyProperty.Register("ClickCommand", typeof(RelayCommand), typeof(RelationshipButton),
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
            RelationshipButton UserControl1Control = d as RelationshipButton;
            UserControl1Control.OnClickCommandChanged(e);
        }

        private void OnClickCommandChanged(DependencyPropertyChangedEventArgs e)
        {
            ClickCommand = (RelayCommand)e.NewValue;
        }

        #endregion

        #endregion
    }
}
