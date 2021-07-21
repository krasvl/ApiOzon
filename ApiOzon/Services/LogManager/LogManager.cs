using ApiOzon.Data.LogLevelRepository;
using ApiOzon.Data.LogRepository;
using ApiOzon.Models.Logs;
using ApiOzon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOzon.Services.LogManager
{
    public class LogManager : ILogManager
    {
        private readonly ILogRepository _logRepository;
        private readonly ILogLevelRepository _logLevelRepository;

        public LogManager(ILogRepository logRepository, ILogLevelRepository logLevelRepository)
        {
            _logRepository = logRepository;
            _logLevelRepository = logLevelRepository;
        }

        public async Task<AddLogResult> AddLogAsync(CrtLogViewModel model)
        {
            var result = new AddLogResult();
            var logLevel = await _logLevelRepository.GetLevelAsync(model.LogLevelName);
            if (logLevel == null)
            {
                result.Errors.Add("IncorrectLogLevelName");
            }
            else
            {
                try
                {
                    var id = await _logRepository.AddLogAsync(new Log { Text = model.Text, LogLevel = logLevel, Source = model.Source, DateTime = DateTime.Now });
                    result.Successed = true;
                    result.LogId = id;
                }
                catch (Exception)
                {
                    result.Errors.Add("AnErrorOccuredWhenAddingTheLog");
                }
        }
            return result;
        }

        public async Task<RemoveLogResult> RemoveLogAsync(int id)
        {
            var result = new RemoveLogResult();
            try
            {
                var count = await _logRepository.RemoveLogAsync(id);
                result.RemovedLogsCount = count;
                if (count == 1)
                    result.Successed = true;
                else
                    result.Errors.Add("WhereIsNoLogsWithThisId");
            }
            catch (Exception)
            {
                result.Errors.Add("AnErrorOccuredWhenRemovingingTheLog");
            }
            return result;
        }

        public async Task<GetLogsResult> GetLogsAsync(string searchString, DateTime startDate, DateTime endDate, string logLevelName)
        {
            var result = new GetLogsResult();
            var logLevel = await _logLevelRepository.GetLevelAsync(logLevelName);
            if (logLevel == null)
            {
                result.Errors.Add("IncorrectLogLevelName");
            }
            else
            {
                try
                {
                    var logs = await _logRepository.GetLogsAsync(l =>
                    (l.Text.Contains(searchString, StringComparison.CurrentCultureIgnoreCase) ||
                    l.Source.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)) &&
                    l.DateTime >= startDate && l.DateTime <= endDate && l.LogLevel.Name == logLevel.Name);
                    result.Successed = true;
                    result.Logs = logs;
                }
                catch (Exception)
                {
                    result.Errors.Add("AnErrorOccuredWhenGettingTheLogs");
                }
            }
            return result;
        }

        public async Task<LogsStatistics> GetLogsStatisticsAsync()
        {
            var result = new LogsStatistics();
            try
            {
                result.CountSavedLogs = await _logRepository.GetCountLogsAsync();
                result.GetLogLevelStatistics = await _logRepository.GetLogLevelStatistics();
                result.GetLogSourceStatistics = await _logRepository.GetSourceStatistics();
                result.Successed = true;
        }
            catch (Exception)
            {
                result.Errors.Add("AnErrorOccuredWhenGettingTheStatistics");
            }
            return result;
        }
    }
}
