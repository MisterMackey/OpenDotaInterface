﻿using System;
using OpenDotaInterface.DBO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace OpenDotaInterface.PublicInterface
{
    /// <summary>
    /// Exposes methods to allow a client to read stuff out of the database
    /// </summary>
    /// <typeparam name="Match"></typeparam>
    public interface IDotaMatchReader<Match>
    {
        Match GetMatchById(Int64 match_id);
        Int64[] ListAllMatches();
        List<Match> Query(Expression<Func<Match, bool>> filter);
    }
}
