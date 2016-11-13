using OpenSupportEngine.TaskRunner.Tasks;
using System;

namespace OpenSupportEngine.TaskRunner.Runners
{
    public class TaskFinishedEventArgs : EventArgs
    {
        public ITask Task { get; private set; }

        public TaskFinishedEventArgs(ITask task)
        {
            Task = task;
        }
    }
}
