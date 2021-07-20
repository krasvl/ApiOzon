using ApiOzon.Data.AppContext;
using ApiOzon.Models.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOzon.Data
{
    public class DataInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            if(!context.Logs.Any() && !context.LogLevels.Any())
            {
                var trace = new LogLevel { Name = "Trace " };
                var debug = new LogLevel { Name = "Debug  " };
                var info = new LogLevel { Name = "Info  " };
                var warning = new LogLevel { Name = "Warning  " };
                var error = new LogLevel { Name = "Error  " };
                var fatal = new LogLevel { Name = "Fatal   " };

                var logLevels = new List<LogLevel> { trace, debug, info, warning, error, fatal };

                context.LogLevels.AddRange(logLevels);

                foreach (var level in logLevels)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        context.Logs.Add(new Log { Text = $"Sample log {i} {level.Name}", LogLevel = level, Source = $"Sample source {i}", DateTime = new DateTime(2021, 7, i, 10, 10, 10) });
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
