using ApiOzon.ViewModels;
using System;
using System.Threading.Tasks;

namespace ApiOzon.Services.LogManager
{
    public interface ILogManager
    {
        Task<AddLogResult> AddLogAsync(CrtLogViewModel crtLogViewModel);
        Task<GetLogsResult> GetLogsAsync(string searchString, DateTime startDate, DateTime endDate, string logLevelName);
        Task<LogsStatistics> GetLogsStatisticsAsync();
        Task<RemoveLogResult> RemoveLogAsync(int id);
    }
}