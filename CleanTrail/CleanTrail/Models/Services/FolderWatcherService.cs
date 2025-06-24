using System;
using System.IO;

namespace CleanTrail.Services
{
    public class FolderWatcherService
    {
        public event Action<string> FolderAccessed;
        private FileSystemWatcher watcher;
        private DateTime lastAccess = DateTime.MinValue;

        public void Watch(string path)
        {
            watcher = new FileSystemWatcher(path)
            {
                IncludeSubdirectories = true,
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastWrite
            };
            watcher.Changed += OnEvent;
            watcher.Created += OnEvent;
            watcher.Renamed += OnEvent;
            watcher.Deleted += OnEvent;
            watcher.EnableRaisingEvents = true;
        }

        private void OnEvent(object sender, FileSystemEventArgs e)
        {
            // 10 saniyede birden fazla tetiklenmesin
            if ((DateTime.Now - lastAccess).TotalSeconds > 10)
            {
                lastAccess = DateTime.Now;
                FolderAccessed?.Invoke(((FileSystemWatcher)sender).Path);
            }
        }

        public void Stop()
        {
            if (watcher != null)
            {
                watcher.EnableRaisingEvents = false;
                watcher.Dispose();
            }
        }
    }
}