using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOzon.Services.LogManager
{
    public class LogResult
    {
        public bool Successed { get; set; } = false;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
