using System;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;

namespace CleanTrail
{
    public partial class App : Application
    {
        public static NotifyIcon TrayIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Tray simgesi
            TrayIcon = new NotifyIcon
            {
                Icon = new Icon("Assets/appicon.ico"),
                Visible = true,
                Text = "CleanTrail"
            };
            TrayIcon.DoubleClick += (s, ev) =>
            {
                var mainWin = Current.MainWindow;
                if (mainWin != null)
                {
                    mainWin.Show();
                    mainWin.WindowState = WindowState.Normal;
                }
            };
            var menu = new ContextMenuStrip();
            menu.Items.Add("Göster", null, (s, ev) => {
                var mainWin = Current.MainWindow;
                if (mainWin != null)
                {
                    mainWin.Show();
                    mainWin.WindowState = WindowState.Normal;
                }
            });
            menu.Items.Add("Çıkış", null, (s, ev) => {
                TrayIcon.Visible = false;
                Current.Shutdown();
            });
            TrayIcon.ContextMenuStrip = menu;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            TrayIcon.Visible = false;
            base.OnExit(e);
        }
    }
}