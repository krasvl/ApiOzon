using ApiOzon.Models.Logs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiOzon.Data.LogRepository
{
    public interface ILogRepository
    {
        void AddLogAsync(Log log);
        Task<List<Log>> GetLogsAsync(Func<Log, bool> filter);
        void RemoveLogAsync(int id);
    }
}