using ApiOzon.Models.Logs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiOzon.Data.LogRepository
{
    public interface ILogRepository
    {
        Task<int> AddLogAsync(Log log);
        Task<int> GetCountLogsAsync();
        Task<Dictionary<string, int>> GetLogLevelStatistics();
        Task<List<Log>> GetLogsAsync(Func<Log, bool> filter);
        Task<Dictionary<string, int>> GetSourceStatistics();
        Task<int> RemoveLogAsync(int id);
    }
}