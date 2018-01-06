using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.DBO
{
    /// <summary>
    /// Factory class that poops out DBObjects based on input.
    /// </summary>
    public class DBObjectFactory
    {
        /// <summary>
        /// creates a winrateanalyzerobject based on the provided object. if the object cannot be used it will throw an exception. 
        /// </summary>
        /// <param name="resource">the object to base the return value on</param>
        /// <returns></returns>
        public WinrateAnalyzerDBObject CreateObject(Object resource)
        {
            
        }
    }
}
