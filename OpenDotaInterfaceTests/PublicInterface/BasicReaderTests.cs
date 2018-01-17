using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDotaInterface.DBO;
using OpenDotaInterface.PublicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine(match.ToString());
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
            throw new NotImplementedException();
        }
    }
}