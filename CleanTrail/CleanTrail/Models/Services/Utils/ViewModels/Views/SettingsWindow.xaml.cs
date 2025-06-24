using System.Windows;

namespace CleanTrail.Views
{
    public partial class SettingsWindow : Window
    {
        public static bool CleanRecent = true;
        public static bool CleanQuick = true;
        public static bool CleanThumb = true;

        public SettingsWindow()
        {
            InitializeComponent();
            chkRecent.IsChecked = CleanRecent;
            chkQuickAccess.IsChecked = CleanQuick;
            chkThumb.IsChecked = CleanThumb;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            CleanRecent = chkRecent.IsChecked == true;
            CleanQuick = chkQuickAccess.IsChecked == true;
            CleanThumb = chkThumb.IsChecked == true;
            MessageBox.Show("Ayarlar kaydedildi.", "CleanTrail", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}