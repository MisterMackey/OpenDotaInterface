using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DACommonLibrary.Interfaces;
using DACommonLibrary.ModelObjects;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace DotaMatchAnalyzerClient.Functions
{
    public class ManagerHelper
    {
        [Import(typeof(IDotaMatchDownloader))]
        public IDotaMatchDownloader downloader;
        [Import(typeof(IDotaMatchReader<Match>))]
        public IDotaMatchReader<Match> reader;
        public event Action DownloadFinished;
        public ManagerHelper()
        {
            AssembleComponents();
        }

        private void AssembleComponents()
        {
            try
            {
                //Step 1: Initializes a new instance of the 
                //        System.ComponentModel.Composition.Hosting.AssemblyCatalog  
                //        class with the current executing assembly.
                var acatalog = new ApplicationCatalog();

                //the following should be removed outside of dev environments. it is only added so the library containing the downloader
                //and other parts can be found, as they live in a seperate project and the dll is in a different folder
                string currpath = Environment.CurrentDirectory;
                currpath = currpath.Replace("DotaMatchAnalyzerClient", "OpenDotaInterface");
                var nothercatalog = new DirectoryCatalog(currpath);
                var catalog = new AggregateCatalog(acatalog, nothercatalog);

                //Step 2: The assemblies obtained in step 1 are added to the 
                //CompositionContainer
                var container = new CompositionContainer(catalog);

                //Step 3: Composable parts are created here i.e. 
                //the Import and Export components 
                //        assembles here
                container.ComposeParts(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region UIFunctions
        /// <summary>
        /// gets the count of the matches currently in the database
        /// </summary>
        /// <returns></returns>
        public int GetMatchCount()
        {
            int count = reader.ListAllMatches().Count();
            return count;
        }
        /// <summary>
        /// deletes all matches (except 3607383684)
        /// </summary>
        public void DeleteAllMatches()
        {
            reader.Delete(match => match.match_id != 3607383684);
        }

        public void DownloadMatches(long low, long high)
        {
            downloader.DownloadIsFinished += OnDownloadFinished; //subscribe event to be cascaded
            downloader.DownloadRange(low, high); //this just makes threads that do the downloading and then returns.
        }

        private void OnDownloadFinished()
        {
            DownloadFinished.Invoke();
        }
        #endregion
    }
}
