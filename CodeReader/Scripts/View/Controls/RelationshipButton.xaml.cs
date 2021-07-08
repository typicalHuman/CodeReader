﻿using CodeReader.Scripts.Enums;
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
    /// Interaction logic for RelationshipButton.xaml
    /// </summary>
    public partial class RelationshipButton : UserControl, INotifyPropertyChanged
    {
        public RelationshipButton()
        {
            InitializeComponent();
            DataContext = this;
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

        #endregion
    }
}