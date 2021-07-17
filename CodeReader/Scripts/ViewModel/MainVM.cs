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
using Notifications.Wpf;
using Microsoft.Win32;

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

        #region Events
        private void MyCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CodeComponents.UpdateItems();
        }
        #endregion

        #region Properties

        #region CodeComponents
        public CodeComponentsCollection CodeComponents { get; set; } = new CodeComponentsCollection()
        {
            new CodeComponent("Class", "public abstract class Avangard\n{\n}\n", "", CodeComponentType.AbstractClass),
        };
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

        /// <summary>
        /// Path to .cb file.
        /// </summary>
        public string FilePath { get; set; } = string.Empty;

        public HistoryStack History { get; set; } = new HistoryStack();

        #endregion

        #region Commands

        #region SaveCommand
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get => saveCommand ?? (saveCommand = new RelayCommand(obj =>
            {
                if(FilePath == string.Empty)
                    saveAsCommand.Execute(null);
                Saver.Save(CodeComponents, FilePath);
            }));
        }

        #endregion

        #region SaveAsCommand
        private RelayCommand saveAsCommand;
        public RelayCommand SaveAsCommand
        {
            get => saveAsCommand ?? (saveAsCommand = new RelayCommand(obj =>
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Code book file (*.cb)|*.cb";
                if (saveFileDialog.ShowDialog() == true)
                {
                    FilePath = saveFileDialog.FileName;
                    Saver.Save(CodeComponents, FilePath);
                }
            }));
        }

        #endregion


        #region SetFileAssociationCommand
        private RelayCommand setFileAssociationCommand;
        public RelayCommand SetFileAssociationCommand
        {
            get => setFileAssociationCommand ?? (setFileAssociationCommand = new RelayCommand(obj =>
            {
                bool associationResult = Saver.TryAssociate();
                if (!associationResult)
                    NotificationsManager.ShowNotificaton(NonAdministratorModeWarning);
            }));
        }

        #endregion

        #region OpenCommand
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get => openCommand ?? (openCommand = new RelayCommand(obj =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Code book file (*.cb)|*.cb";
                if (openFileDialog.ShowDialog() == true)
                {
                    FilePath = openFileDialog.FileName;
                    CodeComponentsCollection result = Saver.Open(FilePath);
                    History.Clear();
                    CodeComponents.Clear();
                    foreach (CodeComponent comp in result)
                        CodeComponents.Add(comp);
                    App.extendedPanelVM.CurrentComponent = null;
                }
            }));
        }

        #endregion

        #endregion

        #region Notifications

        private static NotificationContent NonAdministratorModeWarning { get; set; } = new NotificationContent()
        {
            Type = NotificationType.Error,
            Title = "Error",
            Message = "To perform this operation you should open the application as an administrator."
        };

        #endregion
    }
}
