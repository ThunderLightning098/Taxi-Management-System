using System;

namespace TaxiManagementAssignment
{
    public class Taxi
    {
        public int Number { get; set; }
        public double CurrentFare { get; set; }
        public string Destination { get; set; }
        public string Location { get; set; }
        public const string IN_RANK = "in rank";
        public const string ON_ROAD = "on the road";
        private Rank rank;
        public Rank Rank { 
            get 
            { 
                return rank; 
            }
            set 
            {
                if (value == null)
                {
                    throw new Exception("Rank cannot be null");
                }

                if (Destination != "")
                {
                    throw new Exception("Cannot join rank if fare has not been dropped");
                }

                else
                {
                    rank = value;
                    Location = IN_RANK;
                }
            }
        }
        public double TotalMoneyPaid = 0;
        public void AddFare(string dest, double agreedPrice)
        {
            Location = ON_ROAD;
            Destination = dest;
            CurrentFare = agreedPrice;
            rank = null;
        }
        public void DropFare(bool priceWasPaid)
        {
            if (priceWasPaid)
            {
                TotalMoneyPaid += CurrentFare;
                Location = ON_ROAD;
                Destination = "";
                CurrentFare = 0;
            }
        }
        public Taxi(int num)
        {
            Number = num;
            CurrentFare = 0;
            Destination = "";
            Location = ON_ROAD;
            TotalMoneyPaid = 0;
        }
    }
}