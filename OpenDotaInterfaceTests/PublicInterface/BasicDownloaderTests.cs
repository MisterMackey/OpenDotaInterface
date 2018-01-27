using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDotaInterface.PublicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DACommonLibrary.Interfaces;

namespace OpenDotaInterface.PublicInterface.Tests
{
    [TestClass()]
    public class BasicDownloaderTests
    {
        bool Finished = false; //for downloadrangetest

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
            Console.WriteLine("Attempting to download the following match: {0}", matchid);
            int result = dl.Download(matchid);
            Console.WriteLine(result);
        }

        [TestMethod()]
        public void DownloadRangeTest()
        {
            //define the range to download
            long Lowest = 3607300500;
            long highest = Lowest + 300L; //just gonna grab a couple hundred

            BasicDownloader dl = new BasicDownloader();
            dl.DataWritten += OnDataWrite; //subscribe to write events
            dl.DownloadIsFinished += OnFinished;
            Console.WriteLine("Downloading from {0} to {1}", Lowest, highest);
            dl.DownloadRange(Lowest, highest);
            //wait for finish
            int MaxTimeout = 600; //i don know man 10 minutes seems plenty long enough
            int CurrentWaitTime = 0;
            while (CurrentWaitTime <= MaxTimeout && Finished == false)
            {
                //waity wait
                System.Threading.Thread.Sleep(10000); //chill out for 10s
            }
            
        }

        public void OnFinished()
        {
            Finished = true;
        }
        public void OnDataWrite(object e,  DownloaderEventArgs eventArgs)
        {
            Console.WriteLine("basicdownloader has written {0} matches to db", eventArgs.AmountWritten);
        }
    }
}