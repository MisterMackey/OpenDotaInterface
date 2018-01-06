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
            //string scriptpath = Environment.CurrentDirectory; //C:\Users\MrMackey\source\repos\OpenDotaInterface\OpenDotaInterfaceTests\bin\Debug
            //scriptpath.Replace(@"OpenDotaInterfaceTests\bin\Debug", @"DotaMatchAnalyzer\Script.R");
            string scriptpath = @"C:\Users\MrMackey\source\repos\OpenDotaInterface\DotaMatchAnalyzer\Script.R";
            string renginepath = Environment.GetEnvironmentVariable("R_HOME", EnvironmentVariableTarget.User) + "\\bin\\rscript.exe";
            result = RScriptRunner.RunFromCmd(scriptpath, renginepath, "");
            Assert.IsFalse(result.Equals(""));
            Console.WriteLine(result);
        }
    }
}