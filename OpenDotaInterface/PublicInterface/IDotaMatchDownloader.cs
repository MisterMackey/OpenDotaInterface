using System;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.PublicInterface
{
    public interface IDotaMatchDownloader
    {
        /// <summary>
        /// downloads the match with the specified ID
        /// </summary>
        /// <param name="match_id"></param>
        /// <returns>some random int</returns>
        int Download(Int64 match_id);
    }
}
