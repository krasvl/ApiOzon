using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOzon.Services.LogManager
{
    public class LogResult
    {
        public bool Successed { get; set; }
        public List<string> Errors = new List<string>();
    }
}
