using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenDotaInterface.PublicInterface;
using OpenDotaInterface.DBO;
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
                var catalog = new ApplicationCatalog();

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
        #endregion
    }
}
