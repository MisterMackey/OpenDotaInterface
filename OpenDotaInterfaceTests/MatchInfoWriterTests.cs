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

namespace OpenDotaInterface.Tests
{
    [TestClass()]
    public class MatchInfoWriterTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            //so a match is kinda too big to just initialize so im gonna go ahead and use the test match for this
            string json = File.ReadAllText(@"C:\Users\MrMackey\source\repos\OpenDotaInterface\OpenDotaInterfaceTests\3607383684.json");
            DBObjectFactory factory = new DBObjectFactory();
            MatchInfoWriter writer = new MatchInfoWriter();
            Match match = factory.CreateMatchFromJson(json);
            writer.Insert(match);
        }
    }
}