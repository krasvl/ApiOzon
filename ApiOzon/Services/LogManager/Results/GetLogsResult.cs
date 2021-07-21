using ApiOzon.Models.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOzon.Services.LogManager
{
    public class GetLogsResult : LogResult
    {
        public List<Log> Logs { get; set; }
    }
}
