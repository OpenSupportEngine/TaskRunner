using OpenSupportEngine.Logging.LoggingProvider;
using OpenSupportEngine.TaskRunner.Tasks;
using System;
using System.Collections.Generic;

namespace OpenSupportEngine.TaskRunner.Runners
{
    public abstract class Runner
    {
        public int Count
        {
            get { return taskList.Count; }
        }
        public bool Running { get; protected set; }
        public bool LastResult { get; protected set; }
        public ILoggingProvider Logger { get; set; }

        public event EventHandler<RunnerFinishedEventArgs> RunnerFinished;

        private uint taskIDCount;
        protected List<ITask> taskList;

        public uint AddTask(ITask task)
        {
            var clonedTask = (ITask)task.Clone();
            clonedTask.ID = taskIDCount++;
            taskList.Add(clonedTask);
            return clonedTask.ID;
        }

        public void RemoveTask(uint id)
        {
            var task = FindTask(id);
            if (task != null)
            {
                taskList.Remove(task);
            }
        }

        public bool TaskExists(uint id)
        {
            return FindTask(id) == null;
        }

        public ITask GetTask(uint id)
        {
            return FindTask(id);
        }

        private ITask FindTask(uint id)
        {
            return taskList.Find(t => t.ID == id);
        }

        protected void OnRunnerFinished(ITask failedTask)
        {
            var eventArgs = new RunnerFinishedEventArgs(
                LastResult,
                failedTask
                );
            RunnerFinished?.Invoke(this, eventArgs);
        }

        protected virtual ITask internalRun(object state)
        {
            var taskFailed = false;
            ITask failedTask = null;
            Logger?.StartLog();
            foreach (var task in taskList)
            {
                if (task.doStuff(state, Logger))
                {
                    failedTask = (ITask)task.Clone();
                    taskFailed = true;
                    break;
                }
            }
            LastResult = taskFailed;
            Logger?.FinishLog();
            return failedTask;
        }

        public abstract void run(object state);
    }
}
