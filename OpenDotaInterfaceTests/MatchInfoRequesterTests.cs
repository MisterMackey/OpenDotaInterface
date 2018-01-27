using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace OpenDotaInterface.Tests
{
    [TestClass()]
    public class MatchInfoRequesterTests
    {
        [TestMethod()]
        public void MatchInfoRequesterTest()
        {
            MatchInfoRequester client = new MatchInfoRequester();

            string result = client.GetJsonFormattedMatchInfo("3607383685").Result;

            Assert.IsNotNull(result);
            Console.WriteLine(result);
            
        }
        [TestMethod()]
        public void ThrottledDownloadTest()
        {
            MatchInfoRequester client = new MatchInfoRequester(3);
            List<string> results = new List<string>();
            Console.WriteLine("starting");
            for (long i = 3607383684; i < 3607383694; i++)
            {
                try
                {
                    string result = client.GetJsonFormattedMatchInfo(i).Result;
                    Console.WriteLine("Match downloaded " + i);
                    Console.WriteLine(result.Substring(0, 10));
                }
                catch (AggregateException e)
                {
                    if (e.InnerExceptions.Count == 1 && e.InnerExceptions[0].GetType() == typeof(System.Net.Http.HttpRequestException)) //if its a webexception caught in an aggregate
                    {
                        Console.WriteLine("match not found");
                    }
                    else { throw; }
                }
            }
    
        }
    }
}