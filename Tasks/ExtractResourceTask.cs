using OpenSupportEngine.Logging.LoggingProvider;
using OpenSupportEngine.Helpers.Resources;
using OpenSupportEngine.Logging;

namespace OpenSupportEngine.TaskRunner.Tasks
{
    public class ExtractResourceTask : ITask
    {
        public uint ID { get; set; }
        public virtual string Name
        {
            get { return GetStartLogMessage(); }
        }

        public virtual ResourceDescriptor Descriptor { get; protected set; }
        public virtual string ExportPath { get; protected set; }

        public ExtractResourceTask(ResourceDescriptor descriptor, string exportPath)
        {
            Descriptor = descriptor;
            ExportPath = exportPath;
        }

        public bool doStuff(object state, ILoggingProvider logger)
        {
            var successful = false;

            logger.LogMessage(GetStartLogMessage(), LoggingCategory.Task);
            successful = ResourceOperations.SaveToFileSystem(Descriptor, ExportPath);
            logger.LogMessage(GetEndLogMessage(successful), LoggingCategory.Task);

            return successful;
        }

        private string GetStartLogMessage()
        {
            return string.Format(
                "Extract \"{0}\" to \"{1}\"",
                Descriptor.FullResourcePath,
                ExportPath
                );
        }

        private string GetEndLogMessage(bool successful)
        {
            return string.Format(
                "Extraction {0}",
                successful ? "was successful" : "failed"
                );
        }
    }
}
