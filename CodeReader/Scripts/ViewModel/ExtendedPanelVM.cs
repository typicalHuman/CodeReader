using CodeReader.Scripts.Interfaces;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Indentation;
using Notifications.Wpf;
using System.Linq;
using CodeBox.Enums;
using System;
using System.Windows;
using System.Windows.Input;

namespace CodeReader.Scripts.ViewModel
{
    /// <summary>
    /// View model for Extended panel.
    /// </summary>
    public class ExtendedPanelVM: BaseViewModel
    {
        #region Properties

        #region Notifications

        private NotificationContent NullSelectedTextError { get; set; } = new NotificationContent()
        {
            Title = "Error",
            Message = "First select a text.",
            Type = NotificationType.Error
        };

        #endregion

        #region CurrentNode

        private ICodeComponent currentComponent;
        public ICodeComponent CurrentComponent
        {
            get => currentComponent;
            set
            {
                currentComponent = value;
                if(currentComponent != null)
                  currentComponent.History.UndoPop();//for removing value from last component
                OnPropertyChanged("CurrentComponent");
            }
        }

        #endregion

        #region IsLabelBoxFocused

        private bool isLabelBoxFocused = false;
        public bool IsLabelBoxFocused
        {
            get => isLabelBoxFocused;
            set
            {
                isLabelBoxFocused = value;
                OnPropertyChanged("IsLabelBoxFocused");
            }
        }

        #endregion

        #region IndentStrategy

        private IIndentationStrategy indentStrategy;
        public IIndentationStrategy IndentStrategy
        {
            get => indentStrategy;
            set
            {
                indentStrategy = value;
                OnPropertyChanged("IndentStrategy");
            }
        }

        #endregion

        #region Document

        private TextDocument document;
        public TextDocument Document
        {
            get => document;
            set
            {
                document = value;
                OnPropertyChanged("Document");
            }
        }

        #endregion

        #endregion

        #region Methods

        private void UpdateIndentation()
        {
            //if it's language from C family
            if (CurrentComponent.Language == Languages.C ||CurrentComponent.Language == Languages.CPP ||
                CurrentComponent.Language == Languages.CSharp )
            IndentStrategy.IndentLines(Document, 1, GetLinesCount(currentComponent.Code));
        }

        private static int GetLinesCount(string s)
        {
            return s.Count(c => c == '\n') + 1;
        }

        #endregion

        #region Commands


        #region CreateNewChildCommand
        private RelayCommand createNewChildCommand;
        public RelayCommand CreateNewChildCommand
        {
            get => createNewChildCommand ?? (createNewChildCommand = new RelayCommand(obj =>
            {
                if(obj == null)
                {
                    NotificationsManager.ShowNotificaton(NullSelectedTextError);
                    return;
                }
                string sourceCode = obj.ToString();
                ICodeComponent newComponent = new CodeComponent
                {
                    Code = sourceCode,
                    Parent = currentComponent
                };
                newComponent.ComponentType = CurrentComponent.ComponentType;
                CurrentComponent.Children.Add(newComponent);
                CurrentComponent = CurrentComponent.Children.Last();
                UpdateIndentation();
                IsLabelBoxFocused = true;
            }));
        }
        #endregion

        #region FocusOnCodeCommand
        private RelayCommand focusOnCodeCommand;
        public RelayCommand FocusOnCodeCommand
        {
            get => focusOnCodeCommand ?? (focusOnCodeCommand = new RelayCommand(obj =>
            {
                if (obj is IInputElement)
                    Keyboard.Focus(obj as IInputElement);
            }));
        }
        #endregion

        #endregion


    }
}
