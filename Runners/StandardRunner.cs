using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupportEngine.TaskRunner.Runners
{
    public class StandardRunner : Runner
    {
        public override void run(object state)
        {
            Running = true;
            internalRun(state);
            Running = false;
            OnRunnerFinished();
        }
    }
}
