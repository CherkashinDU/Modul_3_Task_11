using System.Threading.Tasks;

namespace ConsoleLogger.Services
{
    public interface IFileService
    {
        Task Save(string content, string filePath);
        string GetContent(string filePath);
        void CopyFile(string sourceFileName, string destFileName);
    }
}
