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
        public bool Running { protected set; get; }
        public ILoggingProvider Logger { get; set; }

        public event EventHandler<EventArgs> RunnerFinished;

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
            var task = FindTask(id);
            if (task != null)
            {
                task = (ITask)task.Clone();
                task.ID = id;
            }
            return task;
        }

        private ITask FindTask(uint id)
        {
            return taskList.Find(t => t.ID == id);
        }

        protected void OnRunnerFinished()
        {
            RunnerFinished?.Invoke(this, new EventArgs());
        }

        protected virtual void internalRun(object state)
        {
            Logger?.StartLog();
            taskList.ForEach(t => t.doStuff(state, Logger));
            Logger?.FinishLog();
        }

        public abstract void run(object state);
    }
}
