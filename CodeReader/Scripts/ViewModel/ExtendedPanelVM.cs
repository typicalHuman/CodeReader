using CodeReader.Scripts.Model;

namespace CodeReader.Scripts.ViewModel
{
    /// <summary>
    /// View model for Extended panel.
    /// </summary>
    public class ExtendedPanelVM: BaseViewModel
    {
        #region Properties

        #region CurrentNode

        private CodeComponent currentComponent;
        public CodeComponent CurrentComponent
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

        #endregion


    }
}
