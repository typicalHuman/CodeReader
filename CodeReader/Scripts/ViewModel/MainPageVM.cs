using CodeReader.Scripts.Model;
using System.Collections.Generic;

namespace CodeReader.Scripts.ViewModel
{
    public class MainPageVM: BaseViewModel
    {
        /// <summary>
        /// Recent opened files.
        /// </summary>
        public List<RecentFile> RecentFiles { get; set; } = new List<RecentFile>()
        {
            new RecentFile(){Location = "C:\\Users\\HP\\Desktop\\6502", Name="cBook"},
        };


        #region OpenCommand
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get => openCommand ?? (openCommand = new RelayCommand(obj =>
            {
                if(obj is RecentFile)
                    App.mainVM.OpenFile((obj as RecentFile).GetPath());
            }));
        }
        #endregion
    }
}
