using CodeBox;
using System.Collections.ObjectModel;
using CodeBox.Enums;
using CodeReader.Scripts.Enums;
using Newtonsoft.Json;

namespace CodeReader.Scripts.Interfaces
{
    /// <summary>
    /// Interface for implementation core tree component logic.
    /// </summary>
    public interface ICodeComponent
    {
        /// <summary>
        /// Type of code.
        /// </summary>
        CodeComponentType ComponentType { get; set; }
        /// <summary>
        /// Value which will be shown in TreeView control.
        /// </summary>
        string Label { get; set; }
        /// <summary>
        /// Source code of component.
        /// </summary>
        string Code { get; set; }
        /// <summary>
        /// Description for component.
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Children of component.
        /// </summary>
        CodeComponentsCollection Children { get; }
        /// <summary>
        /// Relationships to this component.
        /// </summary>
        ObservableCollection<IRelationship> Relationships { get; }
        /// <summary>
        /// Parent of component.
        /// </summary>
        [JsonIgnore]
        ICodeComponent Parent { get; set; }
        /// <summary>
        /// Programming language
        /// </summary>
        Languages Language { get; set; }
        /// <summary>
        /// Unique indexer.
        /// </summary>
        string ID { get; }
        /// <summary>
        /// History of file changes.
        /// </summary>
        [JsonIgnore]
        UndoStack History { get; set; }
    }
}
