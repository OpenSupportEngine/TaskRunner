using OpenSupportEngine.TaskRunner.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
