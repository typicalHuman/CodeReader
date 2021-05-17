using CodeReader.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                OnPropertyChanged("CurrentComponent");
            }
        }

        #endregion

        #endregion


    }
}
