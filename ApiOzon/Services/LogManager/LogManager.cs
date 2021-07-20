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

        public LogManager(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<bool> AddLog(string text, string levelName, string source)
        {
            await 
        }
    }
}
