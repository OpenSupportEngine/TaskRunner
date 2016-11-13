using OpenSupportEngine.Logging.LoggingProvider;
using System.Diagnostics;
using OpenSupportEngine.Logging;

namespace OpenSupportEngine.TaskRunner.Tasks
{
    public class RunFileTask : ITask
    {
        public uint ID { get; set; }
        public virtual string Name
        {
            get { return GetStartLogMessage(); }
        }

        public ProcessStartInfo StartInfo { get; protected set; }
        public int ExpectedExitcode { get; protected set; }
        public int LastExitcode { get; protected set; }

        public RunFileTask(ProcessStartInfo startInfo, int expectedExitcode = 0)
        {
            StartInfo = startInfo;
            ExpectedExitcode = expectedExitcode;
        }

        public virtual bool doStuff(object state, ILoggingProvider logger)
        {
            var process = new Process()
            {
                StartInfo = StartInfo
            };

            logger.LogMessage(GetStartLogMessage(), LoggingCategory.Task);
            process.Start();
            process.WaitForExit();
            LastExitcode = process.ExitCode;
            logger.LogMessage(GetEndLogMessage(), LoggingCategory.Task);

            return LastExitcode == ExpectedExitcode;
        }

        private string GetStartLogMessage()
        {
            return string.Format(
                "Run \"{0}\" with arguments \"{1}\"",
                StartInfo.FileName,
                StartInfo.Arguments
                );
        }

        private string GetEndLogMessage()
        {
            return string.Format(
                "Finished with exitcode {0} (exptected {1})",
                LastExitcode,
                ExpectedExitcode
                );
        }
    }
}
