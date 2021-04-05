using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ConsoleLogger.Models;
using ConsoleLogger.Services;

namespace ConsoleLogger
{
    public class Logger
    {
        private static readonly Logger _instance = new Logger();
        private readonly ConfigurationService _configurationService;
        private readonly FileService _fileService;
        private readonly LoggerSettings _loggerSettings;
        private int _countLog;
        private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);

        static Logger()
        {
        }

        private Logger()
        {
            _configurationService = new ConfigurationService();
            _fileService = new FileService();
            _loggerSettings = _configurationService.GetLoggerSettings();
        }

        public event Action BackupHandler;

        public static Logger Instance => _instance;

        public async Task Log(string message)
        {
            await semaphoreSlim.WaitAsync();
            var log = $"{DateTime.Now:hh.mm.ss dd.MM.yyyy}: {message}{Environment.NewLine}";

            await _fileService.Save(log, _loggerSettings.FilePath);
            _countLog++;
            if (_countLog >= _loggerSettings.MaxSize && BackupHandler != null)
            {
                BackupHandler();
                _countLog = 0;
            }

            semaphoreSlim.Release();
        }

        public void Backup()
        {
            var backupFilePath = $"{_loggerSettings.BackupFolderPath}\\{DateTime.UtcNow:yyyyMMddHHmmssFFF}.txt";
            _fileService.CopyFile(_loggerSettings.FilePath, backupFilePath);
        }
    }
}
