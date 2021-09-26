using CodeReader.Scripts.FileSystem;
using CodeReader.Scripts.Model;
using Notifications.Wpf;
using System.IO;

namespace CodeReader.Scripts.ViewModel
{
    public class MainPageVM: BaseViewModel
    {

        #region Notifications

        private NotificationContent FileNotFound { get; set; } = new NotificationContent()
        {
            Message = "File is not found",
            Title = "Error",
            Type=NotificationType.Error
        };

        #endregion

        /// <summary>
        /// Recent opened files.
        /// </summary>
        public RecentFilesList RecentFiles { get; set; } = new RecentFilesList();

        public MainPageVM()
        {
            RecentFilesList historyFiles = Saver.LoadFilesHistory();
            if(historyFiles != null)
                for (int i = 0; i < historyFiles.Count; i++)
                    RecentFiles.Add(historyFiles[i]); 
        }


        #region OpenCommand
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get => openCommand ?? (openCommand = new RelayCommand(obj =>
            {
                if(obj is RecentFile)
                {
                    RecentFile file = obj as RecentFile;
                    string path = file.GetPath();
                    if (File.Exists(path))
                    {
                        App.mainVM.OpenFile(file.GetPath());
                        Saver.SaveFilesHistory(RecentFiles);
                    }
                    else
                        NotificationsManager.ShowNotificaton(FileNotFound);
                }
            }));
        }
        #endregion


        #region DeleteCommand
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get => deleteCommand ?? (deleteCommand = new RelayCommand(obj =>
            {
                if (obj is RecentFile)
                {
                    if(obj is RecentFile)
                        RecentFiles.Remove(obj as RecentFile);
                }
            }));
        }
        #endregion
    }
}
