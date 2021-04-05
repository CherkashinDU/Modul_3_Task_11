namespace ConsoleLogger.Models
{
    public class LoggerSettings
    {
        public string FilePath { get; set; }
        public string BackupFolderPath { get; set; }
        public int MaxSize { get; set; }
    }
}
