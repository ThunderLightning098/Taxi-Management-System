using System.Collections.Generic;

namespace TaxiManagementAssignment
{
    public class RankManager
    {
        public Dictionary<int, Rank> ranks = new Dictionary<int, Rank>();
        public RankManager()
        {
            Rank rank1 = new Rank(1,5);
            ranks.Add(1, rank1);
            Rank rank2 = new Rank(2,2);
            ranks.Add(2, rank2);
            Rank rank3 = new Rank(3,4);
            ranks.Add(3, rank3);
        }
        public Rank FindRank(int rankId)
        {
            if (ranks.ContainsKey(rankId))
            {
                return ranks[rankId];
            }
            else
            {
                return null;
            }
        }
        public bool AddTaxiToRank(Taxi t, int rankId)
        {
            if (!ranks.ContainsKey(rankId) || t.Rank == ranks[rankId] || ranks.ContainsValue(t.Rank) || t.Destination != "")
            {
                return false;
            }
            else
            {
                return ranks[rankId].AddTaxi(t);
            }
        }
        public Taxi FrontTaxiInRankTakesFare(int rankId, string destination, double agreedPrice)
        {
            Rank rank = FindRank(rankId);
            if (rank == null)
            {
                return null;
            }
            Taxi taxi = rank.FrontTaxiTakesFare(destination, agreedPrice);
            if (taxi == null)
            {
                return null;
            }
            else
            {
                return taxi;
            }
        }
    }
}
