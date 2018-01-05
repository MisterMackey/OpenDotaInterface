using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.DBO
{
    /// <summary>
    /// contains an array with details of items purchased and the time of purchase by a hero
    /// </summary>
    public class ItemProgression : WinrateAnalyzerDBObject
    {
        //properties
        private List<ItemPurchase> _ItemProgression = new List<ItemPurchase>();

        public void Add(int time, int itemId)
        {
            ItemPurchase p = new ItemPurchase;
            p.ItemId = itemId;
            p.Time = time;
            this._ItemProgression.Add(p);
        }
        public override bool InsertRecord()
        {
            throw new NotImplementedException();
        }


        private struct ItemPurchase
        {
           public int ItemId;
           public int Time;
        }
    }
}
