using CodeReader.Scripts.Enums;

namespace CodeReader.Scripts.ViewModel
{
    public class ConfirmingWindowVM: BaseViewModel
    {

        private string text;
        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        #region Commands

        #region SelectTypeCommand
        private RelayCommand selectTypeCommand;
        public RelayCommand SelectTypeCommand
        {
            get => selectTypeCommand ?? (selectTypeCommand = new RelayCommand(obj =>
            {
                RelationshipType btnCaption = (RelationshipType)obj;
            }));
            set
            {
                selectTypeCommand = value;
                OnPropertyChanged("SelectTypeCommand");
            }
        }
        #endregion
        #endregion
    }
}
