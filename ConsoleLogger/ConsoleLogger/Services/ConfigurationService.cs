using ConsoleLogger.Models;
using Newtonsoft.Json;

namespace ConsoleLogger.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IFileService _fileService;

        public ConfigurationService()
        {
            _fileService = new FileService();
        }

        public LoggerSettings GetLoggerSettings()
        {
            var filePath = "Configs\\consoleLoggerSettings.json";
            var content = _fileService.GetContent(filePath);

            return JsonConvert.DeserializeObject<LoggerSettings>(content);
        }
    }
}
