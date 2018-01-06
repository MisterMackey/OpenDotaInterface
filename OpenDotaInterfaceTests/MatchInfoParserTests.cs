using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDotaInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenDotaInterface.Tests
{
    [TestClass()]
    public class MatchInfoParserTests
    {
        [TestMethod()]
        public void MatchInfoParserTest()
        {
            MatchInfoParser parser = new MatchInfoParser();
            foreach (var item in parser.debug)
            {
                Console.WriteLine(item.ToString());
            }
        }

        [TestMethod()]
        public void ParseJSONMatchInfoTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ParseJSONMatchInfoTest1()
        {
            throw new NotImplementedException();
        }
    }
}