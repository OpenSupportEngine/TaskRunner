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
        uint ID { set; get; }
        
        void doStuff(object state, ILoggingProvider logger);
    }
}
