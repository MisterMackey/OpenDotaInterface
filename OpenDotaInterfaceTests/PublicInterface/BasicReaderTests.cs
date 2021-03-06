﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDotaInterface.DBO;
using System.Linq.Expressions;
using OpenDotaInterface.PublicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DACommonLibrary.ModelObjects;

namespace OpenDotaInterface.PublicInterface.Tests
{
    [TestClass()]
    public class BasicReaderTests
    {
        [TestMethod()]
        public void GetMatchByIdTest()
        {
            BasicReader reader = new BasicReader();
            Match match = reader.GetMatchById(3607383684); //cuz i know its in there.
            Assert.IsNotNull(match);
        }

        [TestMethod()]
        public void ListAllMatchesTest()
        {
            Int64[] result;
            BasicReader reader = new BasicReader();
            result = reader.ListAllMatches();
            Assert.IsNotNull(result);
            for (int i = 0; i < result.Count(); i++)
            {
                Console.WriteLine(result[i]);
            }
        }

        [TestMethod()]
        public void QueryTest()
        {
            BasicReader reader = new BasicReader();
            Expression<Func<Match, bool>> expression = Match => Match.radiant_win == true;
            List<Match> result = reader.Query(expression);
            foreach (var m in result)
            {
                Console.WriteLine("Radiant won in match {0}", m.match_id);
            }
        }

        [TestMethod()]
        public void DeleteTest()
        {
            long matchid = 3607383684;
            Expression<Func<Match, bool>> expression = match => match.match_id != matchid; //delete all matches except for the one used in the read test
            BasicReader reader = new BasicReader();
            reader.Delete(expression);
            long[] result = reader.ListAllMatches();
            Assert.IsTrue(result.Count() == 1);
        }
    }
}