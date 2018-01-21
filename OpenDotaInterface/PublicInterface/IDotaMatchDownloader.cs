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
        int Download(Int64 match_id);
    }
}
