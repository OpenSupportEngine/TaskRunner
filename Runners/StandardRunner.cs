using OpenSupportEngine.TaskRunner.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupportEngine.TaskRunner.Runners
{
    public class StandardRunner : Runner
    {
        public override void Run(object state)
        {
            ITask failedTask = null;
            Running = true;
            failedTask = internalRun(state);
            Running = false;
            OnRunnerFinished(failedTask);
        }
    }
}
