using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CodeReader.Scripts.ViewModel
{
    public class MainVM: BaseViewModel
    {

        #region Properties

        #region ResizeMode
        private ResizeMode resizeMode = ResizeMode.CanResizeWithGrip;
        public ResizeMode ResizeMode
        {
            get => resizeMode;
            set
            {
                resizeMode = value;
                OnPropertyChanged("ResizeMode");
            }
        }
        #endregion

        #region WindowState

        private WindowState windowState = WindowState.Normal;
        public WindowState WindowState
        {
            get => windowState;
            set
            {
                if (value == WindowState.Normal)
                {
                    WindowBorderThickness = new Thickness(1);
                    ResizeMode = ResizeMode.CanResizeWithGrip;
                }
                windowState = value;
                OnPropertyChanged("WindowState");
            }
        }

        #endregion

        #region WindowBorderThickness

        private Thickness windowBorderThickness = new Thickness(1);
        public Thickness WindowBorderThickness
        {
            get => windowBorderThickness;
            set
            {
                windowBorderThickness = value;
                OnPropertyChanged("WindowBorderThickness");
            }
        }

        #endregion

        #region IsDarkModeEnabled

        private bool isDarkModeEnabled = true;
        public bool IsDarkModeEnabled
        {
            get => isDarkModeEnabled;
            set
            {
                isDarkModeEnabled = value;
                OnPropertyChanged("IsDarkModeEnabled");
            }
        }

        #endregion

        #endregion

        #region Commands


        #region ChangeThemeCommand
        private RelayCommand changeThemeCommand;
        public RelayCommand ChangeThemeCommand
        {
            get => changeThemeCommand ?? (changeThemeCommand = new RelayCommand(obj =>
            {

            }));
        }
        #endregion
        #endregion
    }
}
