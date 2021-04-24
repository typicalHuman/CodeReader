using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace CodeReader.Scripts.ViewModel
{
    ///<summary>
    ///Base for classes which have properties that should update bound values.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged
        /// <summary>
        /// Event for updating value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Method to update bound value.
        /// </summary>
        /// <param name="prop">The name of property that has changed.</param>
        public virtual void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
