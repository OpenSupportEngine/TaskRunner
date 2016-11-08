using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSupportEngine.TaskRunner.Runners
{
    public class AsynchronousRunner : Runner
    {
        public ManualResetEventSlim ResetEvent { get; } =
            new ManualResetEventSlim(true);

        private Thread workerThread;

        public override void run(object state)
        {
            runAsynchronously(state).Wait();
        }

        public Task runAsynchronously(object state)
        {
            var task = new Task(() => runAllTasks(state));

            Running = true;
            ResetEvent.Reset();
            task.Start();
            
            return task;
        }

        private void runAllTasks(object state)
        {
            internalRun(state);
            Running = false;
            ResetEvent.Set();
            OnRunnerFinished();
        }
    }
}
