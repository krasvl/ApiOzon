﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOzon.Models.Logs
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
        public string Source { get; set; }

        public int LogLevelId { get; set; }
        public LogLevel LogLevel { get; set; }
    }
}
