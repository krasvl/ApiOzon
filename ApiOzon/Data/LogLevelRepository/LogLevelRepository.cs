using ApiOzon.Data.AppContext;
using ApiOzon.Models.Logs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOzon.Data.LogLevelRepository
{
    public class LogLevelRepository : ILogLevelRepository
    {
        private readonly ApplicationContext _context;

        public LogLevelRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<LogLevel> GetLevelAsync(string levelName) =>
            await _context.LogLevels.FirstOrDefaultAsync(l => l.Name == levelName);

    }
}
