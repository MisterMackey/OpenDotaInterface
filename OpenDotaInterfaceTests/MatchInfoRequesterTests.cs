using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDotaInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.Tests
{
    [TestClass()]
    public class MatchInfoRequesterTests
    {
        [TestMethod()]
        public void MatchInfoRequesterTest()
        {
            MatchInfoRequester client = new MatchInfoRequester();

            string result = client.GetJsonFormattedMatchInfo("3607383684").Result;

            Assert.IsNotNull(result);
            Console.WriteLine(result);
            
        }
    }
}