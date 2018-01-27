using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DACommonLibrary.Interfaces
{
    /// <summary>
    /// Exposes methods to allow a client to read stuff out of the database
    /// </summary>
    /// <typeparam name="Match"></typeparam>
    public interface IDotaMatchReader<Match>
    {
        /// <summary>
        /// returns a single match with given ID
        /// </summary>
        /// <param name="match_id"></param>
        /// <returns></returns>
        Match GetMatchById(Int64 match_id);
        /// <summary>
        /// returns a list of long's representing all the match ID's in the database
        /// </summary>
        /// <returns></returns>
        Int64[] ListAllMatches();
        /// <summary>
        /// returns matches based on provided filter
        /// </summary>
        /// <param name="filter">A lambda expression returning true or false based on a condition</param>
        /// <returns></returns>
        List<Match> Query(Expression<Func<Match, bool>> filter);
        /// <summary>
        /// deletes matches from database based on filter
        /// </summary>
        /// <param name="filter">A lambda expression returning true or false based on a condition</param>
        void Delete(Expression<Func<Match, bool>> filter);
    }
}
