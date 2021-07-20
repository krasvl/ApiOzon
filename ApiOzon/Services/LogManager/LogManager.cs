using ApiOzon.Data.LogLevelRepository;
using ApiOzon.Data.LogRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOzon.Services.LogManager
{
    public class LogManager
    {
        private readonly ILogRepository _logRepository;
        private readonly ILogLevelRepository _logLevelRepository;

        public LogManager(ILogRepository logRepository, ILogLevelRepository logLevelRepository)
        {
            _logRepository = logRepository;
            _logLevelRepository = logLevelRepository;
        }

        public async Task<bool> AddLog(string text, string levelName, string source)
        {
            var result = new LogResult();
            var logLevel = await _logLevelRepository.GetLevelAsync(levelName);
        }
    }
}
