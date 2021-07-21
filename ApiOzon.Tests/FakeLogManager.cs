using ApiOzon.Services.LogManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiOzon.Tests
{
    class FakeLogManager
    {
        public static LogManager GetLogManager() =>
            new LogManager(new FakeLogRepository(), new FakeLogLevelRepository());
    }
}
