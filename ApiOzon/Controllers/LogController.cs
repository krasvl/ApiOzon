using ApiOzon.Data.AppContext;
using ApiOzon.Services.LogManager;
using ApiOzon.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOzon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogManager _logManager;
        public LogController(ILogManager logManager)
        {
            _logManager = logManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _logManager.GetLogsStatisticsAsync();
            if (result.Successed)
                return Ok(new { result.CountSavedLogs, result.GetLogLevelStatistics, result.GetLogSourceStatistics });
            else
                return BadRequest(result.Errors);
        }

        [HttpGet("{searchString, startDate, endDate, logLevelName}")]
        public async Task<IActionResult> Get(string searchString, DateTime startDate, DateTime endDate, string logLevelName)
        {
            var result = await _logManager.GetLogsAsync(searchString, startDate, endDate, logLevelName);
            if (result.Successed)
                return Ok(result.Logs);
            else
                return BadRequest(result.Errors);
        }

        [HttpPost("{log}")]
        public async Task<IActionResult> Post(CrtLogViewModel log)
        {
            var result = await _logManager.AddLogAsync(log);
            if (result.Successed)
                return Ok(result.LogId);
            else
                return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _logManager.RemoveLogAsync(id);
            if (result.Successed)
                return Ok(result.RemovedLogsCount);
            else
                return BadRequest(new { result.RemovedLogsCount, result.Errors });
        }
    }
}
