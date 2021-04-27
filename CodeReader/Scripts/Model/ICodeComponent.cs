using System.Collections.Generic;

namespace CodeReader.Scripts.Model
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
        List<ICodeComponent> Children { get; }
        /// <summary>
        /// Parent of component.
        /// </summary>
        ICodeComponent Parent { get; set; }
    }
}
