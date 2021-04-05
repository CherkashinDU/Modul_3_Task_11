using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleLogger.Services
{
    public class FileService : IFileService
    {
        public Task Save(string content, string filePath)
        {
            var folderPath = Path.GetDirectoryName(filePath);
            EnsureDirectory(folderPath);
            return File.AppendAllTextAsync(filePath, content);
        }

        public string GetContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public void EnsureDirectory(string folderPath)
        {
            var dirInfo = new DirectoryInfo(folderPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
        }

        public void CopyFile(string sourceFileName, string destFileName)
        {
            var folderPath = Path.GetDirectoryName(destFileName);
            EnsureDirectory(folderPath);
            File.Copy(sourceFileName, destFileName);
        }
    }
}
