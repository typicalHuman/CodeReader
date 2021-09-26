using CodeReader.Scripts.Model;
using Notifications.Wpf;
using System.IO;

namespace CodeReader.Scripts.ViewModel
{
    public class MainPageVM: BaseViewModel
    {
        private const int RECENT_FILES_COUNT = 10;

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
        public RecentFilesList RecentFiles { get; set; } = new RecentFilesList(RECENT_FILES_COUNT)
        {
            new RecentFile(){Location = "C:\\Users\\HP\\Desktop\\6502", Name="cBook"},
        };

        public MainPageVM()
        {
            for (int i = 0; i < 5; i++)
                RecentFiles.Add(new RecentFile() { Location = "C:\\Users\\HP\\Desktop\\6502", Name = $"cBook{i}"});
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
                    RecentFiles.Add(file);
                    string path = file.GetPath();
                    if (File.Exists(path))
                        App.mainVM.OpenFile(file.GetPath());
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
