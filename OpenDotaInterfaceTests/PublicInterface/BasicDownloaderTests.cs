using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDotaInterface.PublicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.PublicInterface.Tests
{
    [TestClass()]
    public class BasicDownloaderTests
    {
        [TestMethod()]
        public void DisposeTest()
        {
            BasicDownloader dl = new BasicDownloader();
            dl.Dispose();

        }

        [TestMethod()]
        public void DownloadTest()
        {
            BasicDownloader dl = new BasicDownloader();
            Random rand = new Random();
            long matchid = 3607300000 + rand.Next(10000, 55555);
            Console.WriteLine("Attempting to download the following match: {0}", matchid );
            int result = dl.Download(matchid);
            Console.WriteLine(result);
        }
    }
}