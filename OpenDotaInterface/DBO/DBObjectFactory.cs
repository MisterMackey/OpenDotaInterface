using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// creates a winrateanalyzerobject based on the provided object. if the object cannot be used it will throw an exception. 
        /// </summary>
        /// <param name="resource">the object to base the return value on</param>
        /// <returns></returns>
        [Obsolete("Use CreateMatchFromJson instead")]
        public WinrateAnalyzerDBObject CreateObject(Object resource)
        {
            //check if object is JToken
            if (resource.GetType() == typeof(JToken))
            {
                JToken Token = (JToken)resource;
                return (Match)Token.ToObject(typeof(Match));
            }
            //if its a jobject
            else if (resource.GetType() == typeof(JObject))
            {
                JObject jObject = (JObject)resource;
                Match returnval = (Match)jObject.ToObject(typeof(Match)); //will fill all properties that have a case insensitive name matching with a token path
                returnval.number_teamfights = jObject.GetValue("teamfights").Count(); //will grab the count of the child tokens of the teamfight token which is essentially the number of recorded teamfights
                return returnval;
            }
            else
            {
                throw new Exception("Could not create DBOobject from given input: " + resource.ToString());
            }
        }
        public Match CreateMatchFromJson(string json)
        {
            Match returnValue = JsonConvert.DeserializeObject<Match>(json);
            return returnValue;
        }
    }
}
