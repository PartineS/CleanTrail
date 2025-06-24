using System;
using System.IO;

namespace CleanTrail.Services
{
    public static class TraceCleanerService
    {
        // Recent Files temizliği
        public static void CleanRecentFiles()
        {
            string recentPath = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
            foreach (string file in Directory.GetFiles(recentPath))
            {
                try { File.Delete(file); } catch { }
            }
        }

        // Quick Access (AutomaticDestinations ve CustomDestinations) temizliği
        public static void CleanQuickAccess()
        {
            string quickAccessPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"Microsoft\Windows\Recent\AutomaticDestinations");
            if (Directory.Exists(quickAccessPath))
            {
                foreach (string file in Directory.GetFiles(quickAccessPath))
                {
                    try { File.Delete(file); } catch { }
                }
            }

            string customDestPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"Microsoft\Windows\Recent\CustomDestinations");
            if (Directory.Exists(customDestPath))
            {
                foreach (string file in Directory.GetFiles(customDestPath))
                {
                    try { File.Delete(file); } catch { }
                }
            }
        }

        // Thumbnail cache temizliği
        public static void CleanThumbnailCache()
        {
            string thumbCachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                @"Microsoft\Windows\Explorer");
            if (Directory.Exists(thumbCachePath))
            {
                foreach (string file in Directory.GetFiles(thumbCachePath, "thumbcache_*.db"))
                {
                    try { File.Delete(file); } catch { }
                }
            }
        }

        // Chrome tarayıcı geçmişi temizliği
        public static void CleanBrowserHistory()
        {
            string chromePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Google\\Chrome\\User Data\\Default\\History");
            try
            {
                if (File.Exists(chromePath))
                    File.Delete(chromePath);
            }
            catch { /* Dosya kullanımda olabilir, hata yoksayılır */ }
        }

        // Edge tarayıcı geçmişi temizliği
        public static void CleanEdgeHistory()
        {
            string edgePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Microsoft\\Edge\\User Data\\Default\\History");
            try
            {
                if (File.Exists(edgePath))
                    File.Delete(edgePath);
            }
            catch { }
        }

        // Firefox tarayıcı geçmişi temizliği
        public static void CleanFirefoxHistory()
        {
            string ffProfileRoot = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Mozilla\\Firefox\\Profiles");
            if (Directory.Exists(ffProfileRoot))
            {
                foreach (var dir in Directory.GetDirectories(ffProfileRoot))
                {
                    string places = Path.Combine(dir, "places.sqlite");
                    try
                    {
                        if (File.Exists(places))
                            File.Delete(places);
                    }
                    catch { }
                }
            }
        }

        // Opera tarayıcı geçmişi temizliği
        public static void CleanOperaHistory()
        {
            string operaPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Opera Software\\Opera Stable\\History");
            try
            {
                if (File.Exists(operaPath))
                    File.Delete(operaPath);
            }
            catch { }
        }
    }
}