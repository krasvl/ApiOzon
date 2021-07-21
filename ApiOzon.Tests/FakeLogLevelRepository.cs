using ApiOzon.Data.LogLevelRepository;
using ApiOzon.Models.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiOzon.Tests
{
    class FakeLogLevelRepository : ILogLevelRepository
    {
        private List<LogLevel> _logLevels = new List<LogLevel> {
            new LogLevel { Id = 1, Name = "Error"},
            new LogLevel { Id = 2, Name = "Warning" } };

        public Task<LogLevel> GetLevelAsync(string levelName) =>
            Task.Run(() => _logLevels.FirstOrDefault(l => l.Name == levelName));
    }
}
