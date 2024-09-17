using System;
using System.Collections.Generic;

namespace TaxiManagementAssignment
{
    public class TransactionManager
    {
        public List<Transaction> transactions = new List<Transaction>();
        public List<Transaction> GetAllTransactions()
        {
            return transactions;
        }
        public void RecordJoin(int num, int rankId)
        {
            JoinTransaction jointransaction = new JoinTransaction(DateTime.Now, num, rankId);
            transactions.Add(jointransaction);
        }
        public void RecordLeave(int rankId, Taxi t)
        {
            LeaveTransaction leavetransaction = new LeaveTransaction(DateTime.Now, rankId, t);
            transactions.Add(leavetransaction);
        }
        public void RecordDrop(int num, bool pricePaid)
        {
            DropTransaction droptransaction = new DropTransaction(DateTime.Now, num, pricePaid);
            transactions.Add(droptransaction);
        }
    }
}
