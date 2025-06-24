using System.IO;

namespace CleanTrail.Utils
{
    public static class FileUtils
    {
        public static bool SafeDelete(string path)
        {
            try
            {
                File.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}