using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOzon.Services.LogManager
{
    public class RemoveLogResult : LogResult
    {
        public int RemovedLogsCount { get; set; }
    }
}
