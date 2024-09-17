using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class LeaveTransaction : Transaction
    {
        public int Number { get; set; }
        public int Id { get; set; }
        public string Destination { get; set; }
        public double agreedPrice { get; set; }
        public LeaveTransaction(DateTime transactionDatetime, int rankId, Taxi t) : base("Leave", transactionDatetime)
        {
            Number = t.Number;
            Id = rankId;
            Destination = t.Destination;
            agreedPrice = t.CurrentFare;
        }
        public override string ToString()
        {
            string dateStr = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return ($"{dateStr} Leave     - Taxi {Number} from rank {Id} to {Destination} for £{agreedPrice}");
        }
    }
}
