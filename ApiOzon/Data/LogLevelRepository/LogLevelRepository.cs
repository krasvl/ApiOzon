using ApiOzon.Data.AppContext;
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

        public async void GetLevelAsync(string levelName) =>
            await _context.LogLevels.FirstOrDefaultAsync(l => l.Name == levelName);

    }
}
