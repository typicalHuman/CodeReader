﻿using System;
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
using CodeReader.Scripts.Interfaces;
using CodeBox.Enums;

namespace CodeReader.Scripts.ViewModel
{
    public class MainVM: BaseViewModel
    {

        #region Constants

        private const string CODE_BOOK_FILE_FILTER = "Code book file (*.cb)|*.cb";

        private const string CODE_FILE_FILTER = "C# (*.cs)|*.cs|" +
                                                "C++ (*.cpp, *.h)|*.cpp; *.h|" +
                                                "C (*.c, *.h)|*.c; *.h|" +
                                                "Python (*.py)|*.py|" +
                                                "JavaScript (*.js)|*.js|" +
                                                "PHP (*.php)|*.php|" +
                                                "Assembly (*.asm, *.s)|*.asm; *.s" ;

        #endregion

        #region Ctor

        public MainVM()
        {
            CodeComponents.CollectionChanged += (sender, e) => CodeComponents.UpdateItems();
        }

        #endregion


        #region Events
        private void MyCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CodeComponents.UpdateItems();
        }
        #endregion

        #region Properties

        #region CodeComponents
        public CodeComponentsCollection CodeComponents { get; set; } = new CodeComponentsCollection();
        /// <summary>
        /// Collection for saving components values when we're searching an element in searchBox.
        /// </summary>
        public CodeComponentsCollection CodeComponentsBuffer { get; set; } = new CodeComponentsCollection();
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

        #region DefaultLanguage

        private Languages defaultLanguage = Languages.CSharp;
        public Languages DefaultLanguage
        {
            get => defaultLanguage;
            set
            {
                defaultLanguage = value;
                OnPropertyChanged("DefaultLanguage");
            }
        }

        #endregion

        #region ViewMode

        private ViewMode viewMode = ViewMode.Default;
        public ViewMode ViewMode
        {
            get => viewMode;
            set
            {
                viewMode = value;
                OnPropertyChanged("ViewMode");
            }
        }

        #endregion

        #region Notifications

        private static NotificationContent NonAdministratorModeWarning { get; set; } = new NotificationContent()
        {
            Type = NotificationType.Error,
            Title = "Error",
            Message = "To perform this operation you should run the application as administrator."
        };

        private static NotificationContent SavedNotification { get; set; } = new NotificationContent()
        {
            Type = NotificationType.Success,
            Title = "Save info",
            Message = "Saved!"
        };

        #endregion

        /// <summary>
        /// Path to .cb file.
        /// </summary>
        private string FilePath { get; set; } = string.Empty;

        /// <summary>
        /// History of file changes.
        /// </summary>
        public HistoryStack History { get; set; } = new HistoryStack();

        #endregion

        #region Commands

        #region File Commands


        #region ExitCommand

        private RelayCommand exitCommand;
        public RelayCommand ExitCommand
        {
            get => exitCommand ?? (exitCommand = new RelayCommand(obj =>
            {
                Application.Current.Shutdown();
            }));
        }
        #endregion

        #region SaveCommand
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get => saveCommand ?? (saveCommand = new RelayCommand(obj =>
            {
                if (FilePath == string.Empty)
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
                saveFileDialog.Filter = CODE_BOOK_FILE_FILTER;
                if (saveFileDialog.ShowDialog() == true)
                {
                    FilePath = saveFileDialog.FileName;
                    Saver.Save(CodeComponents, FilePath);
                }
                NotificationsManager.ShowNotificaton(SavedNotification);
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
                openFileDialog.Filter = CODE_BOOK_FILE_FILTER;
                if (openFileDialog.ShowDialog() == true)
                {
                    FilePath = openFileDialog.FileName;
                    OpenFile();
                }
            }));
        }

        private void OpenFile()
        {
            CodeComponentsCollection result = Saver.Open(FilePath);
            History.Clear();
            CodeComponents.Clear();
            foreach (CodeComponent comp in result)
                CodeComponents.Add(comp);
            App.extendedPanelVM.CurrentComponent = null;
        }

        #endregion

        #endregion

        #region Edit Commands

        #region Undo

        private RelayCommand undoCommand;
        public RelayCommand UndoCommand
        {
            get => undoCommand ?? (undoCommand = new RelayCommand(obj =>
            {
                App.mainVM.History.Undo();
            }));
        }

        #endregion


        #region Redo

        private RelayCommand redoCommand;
        public RelayCommand RedoCommand
        {
            get => redoCommand ?? (redoCommand = new RelayCommand(obj =>
            {
                App.mainVM.History.Redo();
            }));
        }

        #endregion

        #endregion

        #region CodeCommands

        #region ImportCodeCommand
        private RelayCommand importCodeCommand;
        public RelayCommand ImportCodeCommand
        {
            get => importCodeCommand ?? (importCodeCommand = new RelayCommand(obj =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = CODE_FILE_FILTER;
                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;
                    ICodeComponent importedComponent = Saver.ImportCode(filePath);
                    CodeComponents.Insert(0, importedComponent);
                }
            }));
        }

        #endregion

        #region ChangeDefaultLanguageCommand
        private RelayCommand changeDefaultLanguageCommand;
        public RelayCommand ChangeDefaultLanguageCommand
        {
            get => changeDefaultLanguageCommand ?? (changeDefaultLanguageCommand = new RelayCommand(obj =>
            {
                Enum.TryParse(obj.ToString(), out Languages res);
                DefaultLanguage = res;
            }));
        }

        #endregion

        #region ChangeModeCommand
        public delegate bool NavigateAction(Uri path);
        public NavigateAction Navigate { get; set; }

        private RelayCommand changeModeCommand;
        public RelayCommand ChangeModeCommand
        {
            get => changeModeCommand ?? (changeModeCommand = new RelayCommand(obj =>
            {
                if (ViewMode == ViewMode.Default)
                {
                    Uri ur = new Uri("pack://application:,,,/Scripts/View/Pages/ReferencesViewPage.xaml");
                    Navigate(ur);
                    ViewMode = ViewMode.References;
                }
                else
                {
                    Uri ur = new Uri("pack://application:,,,/Scripts/View/Pages/DefaultViewPage.xaml");
                    Navigate(ur);
                    ViewMode = ViewMode.Default;
                }
            }));
        }

        #endregion

        #endregion

        #region Windows Commands

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

        #endregion

        #region SearchElementCommand
        private RelayCommand searchElementCommand;
        public RelayCommand SearchElementCommand
        {
            get => searchElementCommand ?? (searchElementCommand = new RelayCommand(obj =>
            {
                ICodeComponent[] buffer = new CodeComponent[CodeComponents.Count];
                CodeComponents.CopyTo(buffer, 0);
                CodeComponentsBuffer.Clear();
                CodeComponentsBuffer.AddRange(buffer);
                CodeComponents.Clear();
                foreach (var comp in CodeComponentsBuffer.GetAllElementsWithLabel(obj.ToString()))
                    CodeComponents.Add(comp);
            }));
        }

        #endregion

        #endregion




        #region Methods

        public void OpenFile(string filePath)
        {
            FilePath = filePath;
            if (FilePath == string.Empty || !File.Exists(FilePath))
                return;
            OpenFile(); 
        }

        #endregion

    }
}
