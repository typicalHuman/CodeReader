using Notifications.Wpf;

namespace CodeReader.Scripts.ViewModel
{
    internal static class NotificationsManager
    {
        /// <summary>
        /// Manager for showing notifications.
        /// </summary>
        private static NotificationManager notificationManager { get; set; } = new NotificationManager();

        /// <summary>
        /// Show notification with warning.
        /// </summary>
        internal static void ShowWarning(NotificationContent content)
        {
            notificationManager.Show(content, "NotificationsArea");
        }
    }
}
