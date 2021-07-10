using CodeReader.Scripts.Enums;
using CodeReader.Scripts.Interfaces;

namespace CodeReader.Scripts
{
    /// <summary>
    /// Code tree editing operation.
    /// </summary>
    public class Operation
    {
        #region Ctor
        public Operation(OperationType type, ICodeComponent changedItem, CodeComponentsCollection neighborComponents)
        {
            Type = type;
            ChangedItem = changedItem;
            Neighbors = neighborComponents;
            Index = neighborComponents.IndexOf(changedItem);
        }
        #endregion

        #region Properties

        /// <summary>
        /// Type of changes.
        /// </summary>
        public OperationType Type { get; private set; }
        /// <summary>
        /// Item that was changed.
        /// </summary>
        public ICodeComponent ChangedItem { get; private set; }

        public int Index { get; private set; }

        public CodeComponentsCollection Neighbors { get; set; }

        #endregion
    }
}
