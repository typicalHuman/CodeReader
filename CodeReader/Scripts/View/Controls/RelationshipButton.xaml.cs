using CodeReader.Scripts.Enums;
using CodeReader.Scripts.ViewModel;
using System.Windows;

namespace CodeReader.Scripts.View.Controls
{
    /// <summary>
    /// Interaction logic for RelationshipButton.xaml
    /// </summary>
    public partial class RelationshipButton : BaseUserControl
    {
        #region Ctor

        public RelationshipButton()
        {
            InitializeComponent();
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
