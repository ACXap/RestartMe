using RestartMe.Interface;
using System.IO;

namespace RestartMe
{
    public class LogFile : ILog
    {
        private readonly string _fileLog = @"c:\Temp\logRestart.txt";
        private readonly string _folderLog = @"c:\Temp\";
        
        public void AddLog(string message)
        {
            CreateFolderTemp();
            string[] str = new string[] { message };
            File.AppendAllLines(_fileLog, str);
        }

        private void CreateFolderTemp()
        {
            if (Directory.Exists(_folderLog)) return;

            Directory.CreateDirectory(_folderLog);
        }
    }
}