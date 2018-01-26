using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACommonLibrary.Interfaces
{
    public class DownloaderEventArgs : EventArgs
    {
        public int AmountWritten;
        public long MatchWritten;
    }
}
