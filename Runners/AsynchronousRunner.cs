using System.Threading;
using System.Threading.Tasks;

namespace OpenSupportEngine.TaskRunner.Runners
{
    public class AsynchronousRunner : Runner
    {
        public ManualResetEventSlim ResetEvent { get; } =
            new ManualResetEventSlim(true);

        public override void Run(object state)
        {
            RunAsynchronously(state).Wait();
        }

        public Task RunAsynchronously(object state)
        {
            var task = new Task(() => RunAllTasks(state));

            Running = true;
            ResetEvent.Reset();
            task.Start();

            return task;
        }

        private void RunAllTasks(object state)
        {
            var failedTask = internalRun(state);
            Running = false;
            ResetEvent.Set();
            OnRunnerFinished(failedTask);
        }
    }
}
