using ApiOzon.Data.AppContext;
using ApiOzon.Models.Logs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOzon.Data.LogRepository
{
    public class LogRepository : ILogRepository
    {
        private readonly ApplicationContext _context;

        public LogRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> GetCountLogsAsync() =>
            await _context.Logs.CountAsync();

        public async Task<Dictionary<string, int>> GetSourceStatistics() =>
            await _context.Logs.GroupBy(l => l.Source, l => l.Id, (key, val) => new { Key = key, Val = val.Count()})
            .ToDictionaryAsync(e => e.Key, e => e.Val);

        public async Task<Dictionary<string, int>> GetLogLevelStatistics() =>
            await _context.Logs.Include(l => l.LogLevel).GroupBy(l => l.LogLevel.Name, l => l.Id, (key, val) => new { Key = key, Val = val.Count() })
            .ToDictionaryAsync(e => e.Key, e => e.Val);

        public async Task<int> AddLogAsync(Log log)
        {
            var result = await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<int> RemoveLogAsync(int id)
        {
            var log = await _context.Logs.FirstOrDefaultAsync(l => l.Id == id);
            if (log == null)
                return 0;

            _context.Logs.Remove(log);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<List<Log>> GetLogsAsync(Func<Log, bool> filter) =>
            await Task.FromResult(_context.Logs.Include(l => l.LogLevel).Where(filter).ToList());
    }
}
