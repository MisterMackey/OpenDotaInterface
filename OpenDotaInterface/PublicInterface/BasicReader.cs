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
        /// <returns>a fully filled in match</returns>
        public Match GetMatchById(long match_id)
        {
            using (var db = new DotaMatchContext())
            {
                Match returnMatch =
                        (from matches in db.matches
                         where matches.match_id == match_id
                         select matches).First<Match>();
                returnMatch.objectives =
                        (from objectives in db.objectives
                         where objectives.match_id == match_id
                         select objectives).ToList<Objective>();
                returnMatch.draft_timings =
                        (from draftiming in db.drafts
                         where draftiming.match_id == match_id
                         select draftiming).ToList<DraftTiming>();
                returnMatch.players =
                        (from players in db.players
                         where players.match_id == match_id
                         select players).ToList<Player>();
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
        /// Returns a fat list of matches from the database based on the supplied filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>a list of completely filled in matches</returns>
        public List<Match> Query(Expression<Func<Match, bool>> filter)
        {
            using (var db = new DotaMatchContext())
            {
                List<Match> returnlist = db.matches.Where(filter).ToList<Match>();
                foreach (Match match in returnlist)
                {
                    long match_id = match.match_id;
                    match.objectives =
                           (from objectives in db.objectives
                            where objectives.match_id == match_id
                            select objectives).ToList<Objective>();
                    match.draft_timings =
                            (from draftiming in db.drafts
                             where draftiming.match_id == match_id
                             select draftiming).ToList<DraftTiming>();
                    match.players =
                            (from players in db.players
                             where players.match_id == match_id
                             select players).ToList<Player>();
                }
                return returnlist;
            }
        }

        public void Delete(Expression<Func<Match,bool>> filter)
        {
            using (var db = new DotaMatchContext())
            {
                db.matches.RemoveRange(db.matches.Where(filter));
                db.SaveChanges();
            }
        }
    }
}
