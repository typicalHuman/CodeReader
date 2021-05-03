using CodeReader.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CodeReader.Scripts.ViewModel
{
    public class MainVM: BaseViewModel
    {

        public MainVM()
        {
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
        }
        public ObservableCollection<ICodeComponent> CodeComponents { get; set; } = new ObservableCollection<ICodeComponent>()
        {
            new CodeComponent("Class", "public abstract class Avangard\n{\n}\n", "", CodeComponentType.AbstractClass),
        };

        #region Properties

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
