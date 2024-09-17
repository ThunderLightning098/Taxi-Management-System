using System;

namespace TaxiManagementAssignment
{
    public class DropTransaction : Transaction
    {
        public int Number { get; set; }
        public bool priceWasPaid { get; set; }
        public DropTransaction(DateTime transactionDatetime, int num, bool paid) : base("Drop fare", transactionDatetime)
        {
            Number = num;
            priceWasPaid = paid;
        }
        public override string ToString()
        {
            string dateStr = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            if (priceWasPaid == true)
            {
                return ($"{dateStr} Drop fare - Taxi {Number}, price was paid");
            }
            else
            {
                return ($"{dateStr} Drop fare - Taxi {Number}, price was not paid");
            }
        }
    }
}
