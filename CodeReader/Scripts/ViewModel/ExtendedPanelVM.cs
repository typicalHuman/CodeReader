using CodeReader.Scripts.Interfaces;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Indentation;
using System.Linq;

namespace CodeReader.Scripts.ViewModel
{
    /// <summary>
    /// View model for Extended panel.
    /// </summary>
    public class ExtendedPanelVM: BaseViewModel
    {
        #region Properties

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
                string sourceCode = obj.ToString();
                ICodeComponent newComponent = new CodeComponent
                {
                    Code = sourceCode,
                    Parent = currentComponent
                };
                CurrentComponent.Children.Insert(0, newComponent);
                CurrentComponent = CurrentComponent.Children[0];
                UpdateIndentation();
            }));
        }
        #endregion

        #region BeautifyCommand
        private RelayCommand beautifyCommand;
        public RelayCommand BeautifyCommand
        {
            get => beautifyCommand ?? (beautifyCommand = new RelayCommand(obj =>
            {
                UpdateIndentation();
            }));
        }
        #endregion

        #endregion


    }
}
