using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOzon.Services.LogManager
{
    public class LogsStatistics : LogResult
    {
        public int CountSavedLogs { get; set; }
        public Dictionary<string, int> GetLogLevelStatistics { get; set; }
        public Dictionary<string, int> GetLogSourceStatistics { get; set; }

    }
}
