namespace CleanTrail.Services
{
    public static class NotificationService
    {
        public static void Show(string message, string title = "CleanTrail")
        {
            App.TrayIcon.BalloonTipTitle = title;
            App.TrayIcon.BalloonTipText = message;
            App.TrayIcon.ShowBalloonTip(2000); // 2 saniye
        }
    }
}