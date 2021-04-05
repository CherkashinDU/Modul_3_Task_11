using ConsoleLogger.Models;

namespace ConsoleLogger.Services
{
    public interface IConfigurationService
    {
        LoggerSettings GetLoggerSettings();
    }
}
