using CodeBox.Enums;
using CodeReader.Scripts.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                OnPropertyChanged("label");
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

        public ObservableCollection<ICodeComponent> Children { get; set; } = new ObservableCollection<ICodeComponent>();
        public ICodeComponent Parent { get; set; }

        #endregion

        #endregion

    }
}
