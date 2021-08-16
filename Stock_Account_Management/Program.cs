using Stock_Account_Management.InventoryManagement;
using System;
namespace Stock_Account_Management
{
    class Program
    {
       public const String Inventory_Json = @"E:\Bridglabz\Stock_Account_Management\Stock_Account_Management\InventoryManagement\InventoryOfStocks.json"; //@ define path
        static void Main(string[] args)
        {
            String choice = "";
            InventoryManager main = new InventoryManager();         
            Console.WriteLine("Enter 'add' if u want to ADD an ACCOUNT");
            Console.WriteLine("Enter 'buy' if u want to BUY some shares");
            Console.WriteLine("Enter 'valueof' if u want to Display SHARES of an ACCOUNT");
            Console.WriteLine("Enter 'printreport' if u want to Display SHARES of ALL ACCOUNTS");
            Console.WriteLine("Enter stop to exit!");
            while (choice != "stop")
            {
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {                   
                  
                   case "add":
                               main.AddAccount(Inventory_Json);
                               break;

                    case "valueof":
                               main.ValueOf(Inventory_Json);
                               break;

                    case "buy":
                               main.Buy();
                               break;

                    case "sell":
                               main.Sell();
                               break;

                    case "printreport":
                               main.PrintReport(Inventory_Json);
                               break;
                }
            }

        }
    }
}
