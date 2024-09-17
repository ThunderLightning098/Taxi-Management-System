using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class JoinTransaction : Transaction
    {
        public int Number { get; set; }
        public int Id { get; set; }
        public JoinTransaction(DateTime transactionDatetime, int taxiNum, int rankId) : base("Join", transactionDatetime)
        {
            Number = taxiNum;
            Id = rankId;
        }
        public override string ToString()
        {
            string dateStr = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return ($"{dateStr} Join      - Taxi {Number} in rank {Id}");
        }
    }
}
