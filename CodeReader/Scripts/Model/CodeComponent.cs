using CodeBox;
using CodeBox.Enums;
using CodeReader.Scripts.Enums;
using CodeReader.Scripts.Interfaces;
using CodeReader.Scripts.ViewModel;
using System.Collections.ObjectModel;

namespace CodeReader.Scripts
{

    /// <summary>
    /// Implementation of <see cref="ICodeComponent"/> inteface.
    /// </summary>
    public class CodeComponent: BaseViewModel, ICodeComponent
    {
        #region Constructor

        /// <summary>
        /// Initialize control with children.
        /// </summary>
        /// <param name="label">Label of code component.</param>
        /// <param name="code">Source code.</param>
        /// <param name="description">Description of code block.</param>
        /// <param name="type">Type of code component.</param>
        public CodeComponent(string label = "code", string code = "", string description = "",
            CodeComponentType type = CodeComponentType.Code)
        {
            DefaultInit(label, code, description, type);
        }

        public CodeComponent()
        {
            DefaultInit();
        }

        #endregion

        #region Properties

        #region ComponentType
        private CodeComponentType componentType;
        public CodeComponentType ComponentType
        {
            get => componentType;
            set
            {
                componentType = value;
                OnPropertyChanged("ComponentType");
            }
        }

        #endregion

        #region Label

        private string label;
        public string Label
        {
            get => label;
            set
            {
                label = value;
                OnPropertyChanged("Label");
            }
        }

        #endregion

        #region Code
        private string code;
        public string Code
        {
            get => code;
            set
            {
                code = value;
                OnPropertyChanged("Code");
            }

        }
        #endregion

        #region Description

        private string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        #endregion

        #region Language

        private Languages language;
        public Languages Language
        {
            get => language;
            set
            {
                language = value;
                OnPropertyChanged("Language");
            }
        }

        #endregion

        #region Parent

        private ICodeComponent parent;
        public ICodeComponent Parent
        {
            get => parent;
            set
            {
                parent = value;
                if(parent != null)
                {
                    Language = parent.Language;
                }
                OnPropertyChanged("Parent");
            }
        }

        #endregion

        public CodeComponentsCollection  Children { get; set; } = new CodeComponentsCollection();
        public ObservableCollection<IRelationship> Relationships { get; set; } = new ObservableCollection<IRelationship>();
        public string ID { get; private set; } = string.Empty;
        public UndoStack History { get; set; } = new UndoStack();

        #endregion






        #region Methods

        private void DefaultInit(string label = "code", string code = "", string description = "",
            CodeComponentType type = CodeComponentType.Code)
        {
            Label = label;
            Code = code;
            Description = description;
            ComponentType = type;
            ID = IDGenerator.GenerateID();
        }

        /// <summary>
        /// Duplicate component without references.
        /// </summary>
        public static ICodeComponent Create(ICodeComponent component)
        {
            CodeComponent newComponent = new CodeComponent(component.Label, component.Code, 
                                                           component.Description, component.ComponentType);
            newComponent.Children = CopyChildren(component);
            return newComponent;
        }

        private static CodeComponentsCollection CopyChildren(ICodeComponent parent)
        {
            CodeComponentsCollection result = new CodeComponentsCollection();
            foreach(ICodeComponent child in parent.Children)
            {
                ICodeComponent copiedChild = CopyComponent(child);
                foreach (ICodeComponent subChild in child.Children)
                    copiedChild.Children.AddRange(CopyChildren(child));
                copiedChild.Parent = parent;
                result.Add(copiedChild);
            }
            return result;
        }

        private static ICodeComponent CopyComponent(ICodeComponent component)
        {
            return new CodeComponent(component.Label, component.Code,
                                     component.Description, component.ComponentType);
        }

        #endregion

    }
}
