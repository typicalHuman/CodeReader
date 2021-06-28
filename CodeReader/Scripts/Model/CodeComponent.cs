using CodeBox.Enums;
using CodeReader.Scripts.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodeReader.Scripts.Model
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
            Label = label;
            Code = code;
            Description = description;
            ComponentType = type;
            ID = IDGenerator.GenerateID();
        }

        #endregion

        #region Properties

        #region Public
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

        public ICodeComponent Parent { get; set; }

        public CodeComponentsCollection  Children { get; set; } = new CodeComponentsCollection();
        public ObservableCollection<ICodeComponent> References { get; set; } = new ObservableCollection<ICodeComponent>();
        public ObservableCollection<ICodeComponent> Dependencies { get; set; } = new ObservableCollection<ICodeComponent>();


        #endregion

        #region Private

        /// <summary>
        /// Unique indexer.
        /// </summary>
        private string ID { get; set; } = string.Empty;

        #endregion

        #endregion

        #region Methods
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

        private static CodeComponentsCollection CopyChildren(ICodeComponent component)
        {
            CodeComponentsCollection result = new CodeComponentsCollection();
            foreach(ICodeComponent child in component.Children)
            {
                ICodeComponent copiedChild = CopyComponent(child);
                foreach (ICodeComponent subChild in child.Children)
                    copiedChild.Children.AddRange(CopyChildren(child));
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
