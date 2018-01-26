using System;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACommonLibrary.Interfaces
{
    public interface IDotaMatchDownloader
    {
        /// <summary>
        /// Downloads a single match with given match_id, not threadsafe
        /// </summary>
        /// <param name="match_id">matchid to download</param>
        /// <returns></returns>
        int Download(Int64 match_id);
        /// <summary>
        /// Downloads multiple matches over an (inclusive) range. 
        /// </summary>
        /// <param name="lowestID">the lowest match id. </param>
        /// <param name="highestID">the highest match id</param>
        void DownloadRange(long lowestID, long highestID);

        //todo: remove link from interface to implementation
        event EventHandler<DownloaderEventArgs> DataWritten;
    }
}
