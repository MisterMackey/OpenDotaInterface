using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using OpenDotaInterface.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.DBO.Tests
{
    [TestClass()]
    public class DBObjectFactoryTests
    {
        [TestMethod()]
        public void CreateMatchFromJsonTest()
        {
            DBObjectFactory factory = new DBObjectFactory();
            string json = File.ReadAllText(@"C:\Users\MrMackey\source\repos\OpenDotaInterface\OpenDotaInterfaceTests\3607383684.json");
            Match match = factory.CreateMatchFromJson(json);
            Console.WriteLine(match.ToString());
        }
    }
}