using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Logging.MPLogger
{
    public interface IMPLogger<T>
    {
        T Container { get; set; }
        void LogError(Exception exception, string error = null);
        void LogInfo(string info); 
    }
}
