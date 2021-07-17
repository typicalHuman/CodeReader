using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CodeReader.Scripts.Extensions;
using CodeReader.Scripts.Enums;
using System.IO;
using CodeReader.Scripts.FileSystem;

namespace CodeReader.Scripts.ViewModel
{
    public class MainVM: BaseViewModel
    {

        public MainVM()
        {
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children[0].Parent = CodeComponents[0];
            CodeComponents[0].Children[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[0].Children[0].Children[0].Parent = CodeComponents[0].Children[0];
            CodeComponents.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[1].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[1].Children[0].Parent = CodeComponents[1];
            CodeComponents[1].Children[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[1].Children[0].Children[0].Parent = CodeComponents[1].Children[0];
            CodeComponents[1].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
            CodeComponents[1].Children[1].Parent = CodeComponents[1];
            CodeComponents.CollectionChanged += (sender, e) => CodeComponents.UpdateItems();
        }
        public CodeComponentsCollection CodeComponents { get; set; } = new CodeComponentsCollection()
        {
            new CodeComponent("Class", "public abstract class Avangard\n{\n}\n", "", CodeComponentType.AbstractClass),
        };

        private void MyCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CodeComponents.UpdateItems();
        }

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

        #region SaveCommand
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get => saveCommand ?? (saveCommand = new RelayCommand(obj =>
            {
                Saver.associate();
                //Saver.Save(CodeComponents, "");
                //var a = Saver.Open("");
            }));
        }

        #endregion

        #endregion
    }
}
