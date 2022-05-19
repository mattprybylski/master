using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Logging.MPLogger
{
    public abstract class MPBaseLogger<T> : IMPLogger<T>
    {
     

        public T Container
        {
            get;set;
        }

         
        public void LogError(Exception exception, string error = null)
        {
           
        }

        public void LogInfo(string info)
        {
             
        }
    }
}
