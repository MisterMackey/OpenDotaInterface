using System;
using OpenDotaInterface.DBO;
using OpenDotaInterface.DataBaseLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface
{
    /// <summary>
    /// this class exposes methods to write to DB
    /// </summary>
    public class MatchInfoWriter
    {

       public int Insert(Match match)
        {
            using (var db = new DotaMatchContext())
            {
                db.matches.Add(match);
                int value = db.SaveChanges();
                return value;
            }
        }


    }
}
