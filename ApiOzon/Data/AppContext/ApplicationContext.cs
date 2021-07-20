using ApiOzon.Models.Logs;
using Microsoft.EntityFrameworkCore;

namespace ApiOzon.Data.AppContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }
        public DbSet<LogLevel> LogLevels { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureCreated(); 
        }
    }
}
