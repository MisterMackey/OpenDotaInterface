using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.DBO
{
    /// <summary>
    /// base class for objects representing rows in the winrateanalyzer database contains common methods
    /// </summary>
    public abstract class WinrateAnalyzerDBObject
    {
        public abstract bool InsertRecord(); //inserts this object into the database

    }
}
