using CleanTrail.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using System.IO;

namespace CleanTrail
{
    public partial class MainWindow : Window
    {
        private List<string> watchedFolders = new();
        private List<FolderWatcherService> watchers = new();

        public MainWindow()
        {
            InitializeComponent();
            LoadLog();
        }

        private void chkFolders_Checked(object sender, RoutedEventArgs e)
        {
            spFolders.Visibility = Visibility.Visible;
        }
        private void chkFolders_Unchecked(object sender, RoutedEventArgs e)
        {
            spFolders.Visibility = Visibility.Collapsed;
        }

        private void btnAddFolder_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "İzlenecek klasörü seçin";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!watchedFolders.Contains(dialog.SelectedPath))
                    {
                        watchedFolders.Add(dialog.SelectedPath);
                        lbFolders.Items.Add(dialog.SelectedPath);
                    }
                }
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (chkFolders.IsChecked == true && watchedFolders.Count == 0)
            {
                System.Windows.MessageBox.Show("Klasör geçmişi temizlenecekse en az bir klasör seçmelisiniz!", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Önce tüm watcher'ları temizle
            foreach (var watcher in watchers)
                watcher.Stop();
            watchers.Clear();

            // Klasör izleme gerekiyorsa başlat
            if (chkFolders.IsChecked == true)
            {
                foreach (var folder in watchedFolders)
                {
                    var watcher = new FolderWatcherService();
                    watcher.FolderAccessed += OnFolderAccessed;
                    watcher.Watch(folder);
                    watchers.Add(watcher);
                }
            }


            DoCleanup("Manuel temizlik");
            tbStatus.Text = TryFindResource("StatusCleaned") as string ?? "Durum: Temizlik yapıldı";
            NotificationService.Show(tbStatus.Text);
            LoadLog();
        }


        private void OnFolderAccessed(string path)
        {
            DoCleanup($"Klasör etkinliği: {path}");
            tbStatus.Dispatcher.Invoke(() =>
                tbStatus.Text = $"Durum: {path} klasöründe etkinlik - Temizlik yapıldı!"
            );
            NotificationService.Show(tbStatus.Text);
            LoadLog();
        }


        private void DoCleanup(string reason)
        {
            var cleaned = new List<string>();
            if (chkRecent.IsChecked == true)
            {
                TraceCleanerService.CleanRecentFiles();
                cleaned.Add("Recent");
            }
            if (chkQuick.IsChecked == true)
            {
                TraceCleanerService.CleanQuickAccess();
                cleaned.Add("QuickAccess");
            }
            if (chkThumb.IsChecked == true)
            {
                TraceCleanerService.CleanThumbnailCache();
                cleaned.Add("ThumbCache");
            }
            if (chkChrome.IsChecked == true)
            {
                TraceCleanerService.CleanBrowserHistory();
                cleaned.Add("Chrome");
            }
            if (chkEdge.IsChecked == true)
            {
                TraceCleanerService.CleanEdgeHistory();
                cleaned.Add("Edge");
            }
            if (chkFirefox.IsChecked == true)
            {
                TraceCleanerService.CleanFirefoxHistory();
                cleaned.Add("Firefox");
            }
            if (chkOpera.IsChecked == true)
            {
                TraceCleanerService.CleanOperaHistory();
                cleaned.Add("Opera");
            }
            LogService.Log($"{reason}: {string.Join(", ", cleaned)}");
        }


        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }


        private void chkAutostart_Checked(object sender, RoutedEventArgs e) => StartupService.EnableAutostart();
        private void chkAutostart_Unchecked(object sender, RoutedEventArgs e) => StartupService.DisableAutostart();
        private void btnThemeLight_Click(object sender, RoutedEventArgs e) => SetTheme("Light");
        private void btnThemeDark_Click(object sender, RoutedEventArgs e) => SetTheme("Dark");
        private void SetTheme(string themeName)
        {
            var dict = new ResourceDictionary();
            dict.Source = new System.Uri($"Themes/{themeName}.xaml", System.UriKind.Relative);
            Application.Current.Resources.MergedDictionaries[0] = dict;
        }


        private void btnLangTr_Click(object sender, RoutedEventArgs e) => SetLanguage("tr");
        private void btnLangEn_Click(object sender, RoutedEventArgs e) => SetLanguage("en");
        private void SetLanguage(string lang)
        {
            var dict = new ResourceDictionary();
            dict.Source = new System.Uri($"Lang/{lang}.xaml", System.UriKind.Relative);
            Application.Current.Resources.MergedDictionaries[1] = dict;
        }

        // Log
        private void LoadLog()
        {
            string logFile = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "cleantrail.log");
            if (File.Exists(logFile))
            {
                tbLog.Text = File.ReadAllText(logFile);
                tbLog.ScrollToEnd();
            }
            else
            {
                tbLog.Text = "";
            }
        }
    }
}
