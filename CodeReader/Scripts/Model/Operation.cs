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
            Init(type, changedItem, neighborComponents, neighborComponents.IndexOf(changedItem));
        }

        public Operation(OperationType type, ICodeComponent changedItem, CodeComponentsCollection neighborComponents, int index)
        {
            Init(type, changedItem, neighborComponents, index);
        }
        #endregion

        #region Methods

        private void Init(OperationType type, ICodeComponent changedItem, CodeComponentsCollection neighborComponents, int index)
        {
            Type = type;
            ChangedItem = changedItem;
            Neighbors = neighborComponents;
            Index = index;
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
