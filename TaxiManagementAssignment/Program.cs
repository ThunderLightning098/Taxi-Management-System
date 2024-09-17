using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RankManager rankManager = new RankManager();
            TaxiManager taxiManager = new TaxiManager();
            TransactionManager transactionManager = new TransactionManager();
            UserUI ui = new UserUI(rankManager, taxiManager, transactionManager);
            while (true)
            {
                Console.WriteLine(
                "\nWhat do you want to do?" +
                "\n1. Create a new taxi and add it to a rank." +
                "\n2. Remove a taxi from rank." +
                "\n3. Check if taxi has dropped fare." +
                "\n4. View taxi's location." +
                "\n5. View financial report." +
                "\n6. View transaction log." +
                "\n7. Exit." +
                "\nNote: Please create a new taxi before using it, otherwise the program will fail.\n"
                );
                Console.Write("Please enter your choice: ");
                int Num = Convert.ToInt32(Console.ReadLine());
                if (Num == 1)
                {
                    Console.Write("Please enter a taxi number: ");
                    int TaxiNum = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please enter a rank ID: ");
                    int RankId = Convert.ToInt32(Console.ReadLine());
                    foreach (string joinsrank in ui.TaxiJoinsRank(TaxiNum, RankId))
                    {
                        Console.WriteLine(joinsrank);
                    }
                }
                else if (Num == 2)
                {
                    Console.Write("Please enter a rank ID: ");
                    int RankId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please enter a destination: ");
                    string Dest = Console.ReadLine();
                    Console.Write("Please enter a current fare: ");
                    double CFare = Convert.ToDouble(Console.ReadLine());
                    foreach (string leavesrank in ui.TaxiLeavesRank(RankId, Dest, CFare))
                    {
                        Console.WriteLine(leavesrank);
                    }
                }
                else if (Num == 3)
                {
                    Console.Write("Please enter a taxi number: ");
                    int TaxiNum = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Did the guest pay the fare (Y/N)? ");
                    string yn = Console.ReadLine();
                    if (yn == "Y")
                    {
                        bool PricePaid = true;
                        foreach (string dropsfare in ui.TaxiDropsFare(TaxiNum, PricePaid))
                        {
                            Console.WriteLine(dropsfare);
                        }
                    }
                    else if (yn == "N")
                    {
                        bool PricePaid = false;
                        foreach (string dropsfare in ui.TaxiDropsFare(TaxiNum, PricePaid))
                        {
                            Console.WriteLine(dropsfare);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid answer.");
                    }
                }
                else if (Num == 4)
                {
                    foreach (string TaxiLocation in ui.ViewTaxiLocations())
                    {
                        Console.WriteLine(TaxiLocation);
                    }
                }
                else if (Num == 5)
                {
                    foreach (string Report in ui.ViewFinancialReport())
                    {
                        Console.WriteLine(Report);
                    }
                }
                else if (Num == 6)
                {
                    foreach (string Trans in ui.ViewTransactionLog())
                    {
                        Console.WriteLine(Trans);
                    }
                }
                else if (Num == 7)
                {
                    Console.WriteLine("Thank you for using!");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid choice.");
                }
            }
        }
    }

}
