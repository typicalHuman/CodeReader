using CodeReader.Scripts.Enums;
using System;

namespace CodeReader.Scripts.ViewModel
{
    public class ConfirmingWindowVM: BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Action that will be executed after relationship type selection.
        /// </summary>
        public Action WindowCloseAction { get; set; }

        #region Relationship Type

        private RelationshipType relationshipType;
        /// <summary>
        /// For setting relationship type by confirming window buttons.
        /// </summary>
        public RelationshipType RelationshipType
        {
            get => relationshipType;
            set
            {
                relationshipType = value;
                OnPropertyChanged("RelationshipType");
            }
        }

        #endregion

        #endregion

        #region Commands

        #region SelectTypeCommand
        private RelayCommand selectTypeCommand;
        public RelayCommand SelectTypeCommand
        {
            get => selectTypeCommand ?? (selectTypeCommand = new RelayCommand(obj =>
            {
                RelationshipType = (RelationshipType)obj;
                WindowCloseAction?.Invoke();
            }));
        }
        #endregion
        #endregion
    }
}
