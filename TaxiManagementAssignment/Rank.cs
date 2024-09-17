using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class Rank
    {
        public int Id { get; set; }
        public List<Taxi> taxiSpaces = new List<Taxi>();
        public int NumberOfTaxiSpaces { get; set; }
        public Rank(int rankId, int spaceNum)
        {
            Id = rankId;
            NumberOfTaxiSpaces = spaceNum;
        }
        public bool AddTaxi(Taxi t)
        {
            if (NumberOfTaxiSpaces == 0)
            {
                return false;
            }
            else
            {
                t.Rank = this;
                taxiSpaces.Add(t);
                NumberOfTaxiSpaces--;
                return true;
            }
        }
        public Taxi FrontTaxiTakesFare(string dest, double agreedPrice)
        {
            if (taxiSpaces.Count == 0)
            {
                return null;
            }
            else
            {
                Taxi t = taxiSpaces[0];
                taxiSpaces.RemoveAt(0);
                NumberOfTaxiSpaces++;
                return t;
            }
        }
    }
}
