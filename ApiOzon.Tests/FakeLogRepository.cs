using ApiOzon.Data.LogRepository;
using ApiOzon.Models.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiOzon.Tests
{
    class FakeLogRepository : ILogRepository
    {
        private List<Log> _logs = new List<Log> {
            new Log { Id = 1, Text = "text 1", Source = "source 1", DateTime = new DateTime(2021, 07, 01) },
            new Log { Id = 2, Text = "text 2", Source = "source 2", DateTime = new DateTime(2021, 07, 02) },
            new Log { Id = 3, Text = "text 3", Source = "source 1", DateTime = new DateTime(2021, 07, 01) } };

        public FakeLogRepository()
        {
            var logLevels = new FakeLogLevelRepository();
            var error = logLevels.GetLevelAsync("Error").Result;
            var warning = logLevels.GetLevelAsync("Warning").Result;
            _logs[0].LogLevel = error;
            _logs[0].LogLevelId = error.Id;
            _logs[1].LogLevel = warning;
            _logs[1].LogLevelId = warning.Id;
            _logs[2].LogLevel = error;
            _logs[2].LogLevelId = error.Id;
        }

        public Task<int> AddLogAsync(Log log)
        {
            _logs.Add(log);
            return Task.Run(() => 4);
        }

        public Task<int> GetCountLogsAsync()
        {
            return Task.Run(() => 3);
        }

        public Task<Dictionary<string, int>> GetLogLevelStatistics()
        {
            return Task.Run(() => new Dictionary<string, int> { { "Error", 2 }, { "Warning", 1 } });
        }

        public Task<List<Log>> GetLogsAsync(Func<Log, bool> filter)
        {
            return Task.Run(() => _logs.Where(filter).ToList());
        }

        public Task<Dictionary<string, int>> GetSourceStatistics()
        {
            return Task.Run(() => new Dictionary<string, int> { { "source 1", 2 }, { "source 2", 1 } });
        }

        public Task<int> RemoveLogAsync(int id)
        {
            var log = _logs.FirstOrDefault(l => l.Id == id);
            if(log != null)
            {
                _logs.Remove(log);
                return Task.Run(() => 1);
            }
            else
                return Task.Run(() => 0);
        }
    }
}
