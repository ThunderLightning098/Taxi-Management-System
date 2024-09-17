using System;

namespace TaxiManagementAssignment
{
    public abstract class Transaction
    {
        public DateTime TransactionDatetime { get; set; }
        public string TransactionType { get; set; }
        public Transaction(string type, DateTime datetime)
        {
            TransactionDatetime = datetime;
            TransactionType = type;
        }
    }
}
