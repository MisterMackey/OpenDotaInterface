using System;
using System.ComponentModel.Composition;
using OpenDotaInterface.DBO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.PublicInterface
{
    [Export(typeof(IDotaMatchDownloader))]
    public sealed class BasicDownloader : IDotaMatchDownloader, IDisposable
    {
        //members to request json, parse it and write it to DB
        private MatchInfoRequester requester = new MatchInfoRequester();
        private MatchInfoWriter writer = new MatchInfoWriter();
        private DBObjectFactory factory = new DBObjectFactory();

        public void Dispose()
        {
            ((IDisposable)requester).Dispose();
        }

        int IDotaMatchDownloader.Download(long match_id)
        {
            string json = requester.GetJsonFormattedMatchInfo(match_id).Result;
            Match match = factory.CreateMatchFromJson(json);
            int result = writer.Insert(match);
            return result;
        }
    }
}
