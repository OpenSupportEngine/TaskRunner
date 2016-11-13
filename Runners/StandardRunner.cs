using OpenSupportEngine.TaskRunner.Tasks;

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
