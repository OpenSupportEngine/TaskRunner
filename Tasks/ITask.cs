using OpenSupportEngine.Logging.LoggingProvider;

namespace OpenSupportEngine.TaskRunner.Tasks
{
    public interface ITask
    {
        uint ID { get; set; }
        string Name { get; }

        bool doStuff(object state, ILoggingProvider logger);
    }
}
