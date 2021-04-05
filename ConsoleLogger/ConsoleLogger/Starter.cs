using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleLogger.Models;

namespace ConsoleLogger
{
    public class Starter
    {
        private readonly string _message = " Action";
        private Logger _logger = Logger.Instance;

        public Task Run()
        {
            _logger.BackupHandler += _logger.Backup;
            var tasks = new List<Task>();
            for (int i = 0; i < 2; i++)
            {
                tasks.Add(RunLog());
            }

            return Task.WhenAll(tasks);
        }

        public Task RunLog()
        {
            var result = new List<Task>();
            for (int i = 0; i < 50; i++)
            {
                result.Add(_logger.Log(_message));
            }

            return Task.WhenAll(result);
        }
    }
}
