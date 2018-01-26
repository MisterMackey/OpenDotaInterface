using System;
using OpenDotaInterface.DBO;
using OpenDotaInterface.DataBaseLayer;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DACommonLibrary.ModelObjects;
using DACommonLibrary.Interfaces;

namespace OpenDotaInterface.PublicInterface
{
    /// <summary>
    /// provides basic functions to read from DB
    /// </summary>
    [Export(typeof(IDotaMatchReader<Match>))]
    public class BasicReader : IDotaMatchReader<Match>
    {
        /// <summary>
        /// Attempts to find the match with given ID in the database and returns it as a match object
        /// </summary>
        /// <param name="match_id"></param>
        /// <returns></returns>
        public Match GetMatchById(long match_id)
        {
            using (var db = new DotaMatchContext())
            {
                Match returnMatch =
                        (from matches in db.matches
                         where matches.match_id == match_id
                         select matches).First<Match>();
                return returnMatch;
            }
        }

        /// <summary>
        /// returns a list of all match ID's which are in the DB
        /// </summary>
        /// <returns></returns>
        public long[] ListAllMatches()
        {
            using (var db = new DotaMatchContext())
            {
                return db.matches.Select(m => m.match_id).ToArray();
            }
        }

        /// <summary>
        /// Returns an IQueryable from the database based on the supplied filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Match> Query(Expression<Func<Match, bool>> filter)
        {
            using (var db = new DotaMatchContext())
            {
                return db.matches.Where(filter).ToList<Match>();
            }
        }
    }
}
