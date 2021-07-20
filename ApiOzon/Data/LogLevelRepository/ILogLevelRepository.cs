using ApiOzon.Models.Logs;
using System.Threading.Tasks;

namespace ApiOzon.Data.LogLevelRepository
{
    public interface ILogLevelRepository
    {
        Task<LogLevel> GetLevelAsync(string levelName);
    }
}