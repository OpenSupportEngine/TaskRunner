using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenSupportEngine.Logging.LoggingProvider;
using OpenSupportEngine.Logging;
using System.Threading;

namespace OpenSupportEngine.TaskRunner.Tasks
{
    public class SleepTask : ITask
    {
        public uint ID { get; set; }
        public virtual string Name
        {
            get { return GetStartLogMessage(); }
        }

        public int SleepTime { get; protected set; }

        public SleepTask(int sleepTime)
        {
            SleepTime = sleepTime;
        }

        public bool doStuff(object state, ILoggingProvider logger)
        {
            logger.LogMessage(GetStartLogMessage(), LoggingCategory.Task);
            Thread.Sleep(SleepTime);
            return true;
        }

        private string GetStartLogMessage()
        {
            return string.Format(
                "Sleep for {0} ms",
                SleepTime
                );
        }
    }
}
