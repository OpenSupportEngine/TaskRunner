using OpenSupportEngine.Logging.LoggingProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupportEngine.TaskRunner.Tasks
{
    public interface ITask : ICloneable
    {
        uint ID { get; set; }
        string Name { get; }
        
        bool doStuff(object state, ILoggingProvider logger);
    }
}
