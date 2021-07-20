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

        public async void AddLogAsync(Log log)
        {
            await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();
        }


        public async void RemoveLogAsync(int id)
        {
            _context.Logs.Remove(await _context.Logs.FirstOrDefaultAsync(l => l.Id == id));
            await _context.SaveChangesAsync();
        }


        public async Task<List<Log>> GetLogsAsync(Func<Log, bool> filter) =>
            await Task.FromResult(_context.Logs.Where(filter).ToList());
    }
}
