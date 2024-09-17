using System.Collections.Generic;

namespace TaxiManagementAssignment
{
    public class TaxiManager
    {
        public SortedDictionary<int, Taxi> taxis = new SortedDictionary<int, Taxi>();
        public SortedDictionary<int, Taxi> GetAllTaxis()
        {
            return taxis;
        }
        public Taxi FindTaxi(int num)
        {
            if (taxis.ContainsKey(num))
            {
                return taxis[num];
            }
            else
            {
                return null;
            }
        }
        public Taxi CreateTaxi(int num)
        {
            Taxi taxi = FindTaxi(num);
            if (taxi != null)
            {
                return taxi;
            }
            else
            {
                taxi = new Taxi(num);
                taxis.Add(num, taxi);
                return taxi;
            }
        }
    }
}
