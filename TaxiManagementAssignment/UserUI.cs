using System.Collections.Generic;

namespace TaxiManagementAssignment
{
    public class UserUI
    {
        public TaxiManager taxiMgr;
        public RankManager rankMgr;
        public TransactionManager transactionMgr;
        public UserUI(RankManager rkMgr, TaxiManager txMgr, TransactionManager trMgr)
        {
            this.rankMgr = rkMgr;
            this.transactionMgr = trMgr;
            this.taxiMgr = txMgr;
        }
        public List<string> TaxiJoinsRank(int num, int rankId)
        {
            List<string> taxijoinsrank = new List<string>();
            Taxi taxi = taxiMgr.CreateTaxi(num);
            if (rankMgr.AddTaxiToRank(taxi, rankId))
            {
                transactionMgr.RecordJoin(num, rankId);
                taxijoinsrank.Add($"Taxi {num} has joined rank {rankId}.");
            }
            else
            {
                taxijoinsrank.Add($"Taxi {num} has not joined rank {rankId}.");
            }
            return taxijoinsrank;
        }
        public List<string> TaxiLeavesRank(int rankId, string destination, double agreedPrice)
        {
            List<string> taxileavesrank = new List<string>();
            Taxi taxi = rankMgr.FrontTaxiInRankTakesFare(rankId, destination, agreedPrice);
            if (taxi == null)
            {
                taxileavesrank.Add($"Taxi has not left rank {rankId}.");
            }
            else
            {
                taxi.AddFare(destination, agreedPrice);
                transactionMgr.RecordLeave(rankId, taxi);
                taxileavesrank.Add($"Taxi {taxi.Number} has left rank {rankId} to take a fare to {destination} for £{agreedPrice}.");
            }
            return taxileavesrank;
        }
        public List<string> TaxiDropsFare(int num, bool pricePaid)
        {
            List<string> taxidropsfare = new List<string>();
            Taxi taxi = taxiMgr.FindTaxi(num);
            if (taxi.Location == Taxi.IN_RANK)
            {
                taxidropsfare.Add($"Taxi {num} has not dropped its fare.");
            }
            else
            {
                if (pricePaid)
                {
                    taxi.DropFare(pricePaid);
                    taxidropsfare.Add($"Taxi {num} has dropped its fare and the price was paid.");
                }
                else
                {
                    taxidropsfare.Add($"Taxi {num} has dropped its fare and the price was not paid.");
                }
                transactionMgr.RecordDrop(num, pricePaid);
            }
            return taxidropsfare;
        }
        public List<string> ViewTaxiLocations()
        {
            List<string> taxilocations = new List<string>();
            SortedDictionary<int, Taxi> taxis = taxiMgr.GetAllTaxis();
            taxilocations.Add("Taxi locations");
            taxilocations.Add("==============");
            if (taxis.Count == 0)
            {
                taxilocations.Add("No taxis");
            }

            else
            {
                foreach (Taxi taxi in taxis.Values)
                {
                    if (taxi.Location == Taxi.IN_RANK)
                    {
                        taxilocations.Add($"Taxi {taxi.Number} is in rank {taxi.Rank.Id}");
                    }
                    else
                    {
                        if (taxi.Destination != "")
                        {
                            taxilocations.Add($"Taxi {taxi.Number} is on the road to {taxi.Destination}");
                        }
                        else
                        {
                            taxilocations.Add($"Taxi {taxi.Number} is on the road");
                        }
                    }
                }
            }
            return taxilocations;
        }
        public List<string> ViewFinancialReport()
        {
            List<string> financialreport = new List<string>();
            SortedDictionary<int, Taxi> taxis = taxiMgr.GetAllTaxis();
            double sum = 0;
            financialreport.Add("Financial report");
            financialreport.Add("================");
            if (taxis.Count == 0)
            {
                financialreport.Add("No taxis, so no money taken");
            }
            else
            {
                foreach (Taxi taxi in taxis.Values)
                {
                    sum += taxi.TotalMoneyPaid;
                    financialreport.Add(string.Format($"Taxi {taxi.Number}      {taxi.TotalMoneyPaid:0.00}"));
                }
                financialreport.Add("           ======");
                financialreport.Add(string.Format($"Total:       {sum:0.00}"));
                financialreport.Add("           ======");
            }
            return financialreport;
        }
        public List<string> ViewTransactionLog()
        {
            List<string> transactionlog = new List<string>();
            List<Transaction> transactions = transactionMgr.GetAllTransactions();
            transactionlog.Add("Transaction report");
            transactionlog.Add("==================");
            if (transactions.Count == 0)
            {
                transactionlog.Add("No transactions");
            }
            else
            {
                foreach (Transaction transaction in transactions)
                {
                    transactionlog.Add(transaction.ToString());
                }
            }
            return transactionlog;
        }
    }
}
