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
    public class RScriptRunnerTests
    {
        [TestMethod()]
        public void RunFromCmdTest()
        {
            //C:\Users\C51188\Documents\Projects\OpenDotaInterface\DotaMatchAnalyzer\Script.R

            string result = "";
            result = RScriptRunner.RunFromCmd(@"C:\Users\C51188\Documents\Projects\OpenDotaInterface\DotaMatchAnalyzer\Script.R", @"C:\Program Files\R\R-3.4.3\bin\rscript.exe", "");
            Assert.IsFalse(result.Equals(""));
            Console.WriteLine(result);
        }
    }
}