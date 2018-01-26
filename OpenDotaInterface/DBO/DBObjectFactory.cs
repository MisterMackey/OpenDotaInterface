using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DACommonLibrary.ModelObjects;

namespace OpenDotaInterface.DBO
{
    /// <summary>
    /// Factory class that poops out DBObjects based on input.
    /// </summary>
    public class DBObjectFactory
    {
        //members
        
        public DBObjectFactory()
        {
            
        }
        
        /// <summary>
        /// ignores null values
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public Match CreateMatchFromJson(string json)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;
            settings.NullValueHandling = NullValueHandling.Ignore;
            Match returnValue = JsonConvert.DeserializeObject<Match>(json, settings);
            return returnValue;
        }
    }
}
