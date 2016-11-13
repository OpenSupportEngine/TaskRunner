using OpenSupportEngine.TaskRunner.Tasks;
using System;

namespace OpenSupportEngine.TaskRunner.Runners
{
    public class RunnerFinishedEventArgs : EventArgs
    {
        public bool WasSuccessful { get; private set; }
        public ITask FailedTask { get; private set; }

        public RunnerFinishedEventArgs(bool wasSuccessful, ITask failedTask)
        {
            WasSuccessful = wasSuccessful;
            FailedTask = failedTask;
        }
    }
}
