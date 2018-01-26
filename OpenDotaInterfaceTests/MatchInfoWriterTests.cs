using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using OpenDotaInterface.DBO;
using OpenDotaInterface.DataBaseLayer;
using OpenDotaInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DACommonLibrary.ModelObjects;

namespace OpenDotaInterface.Tests
{
    [TestClass()]
    public class MatchInfoWriterTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            Random rand = new Random();
            long matchid = 3607300000 + rand.Next(10000, 55555);
            Console.WriteLine("Attempting to download the following match: {0}", matchid);
            MatchInfoRequester requester = new MatchInfoRequester();
            string json = requester.GetJsonFormattedMatchInfo(matchid.ToString()).Result;
            DBObjectFactory factory = new DBObjectFactory();
            MatchInfoWriter writer = new MatchInfoWriter();
            Match match = factory.CreateMatchFromJson(json);
            writer.Insert(match);
        }
    }
}