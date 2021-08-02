using Stock_Account_Management.InventoryManagement;
using System;
namespace Stock_Account_Management
{
    class Program
    {
       public const String Inventory_Json = @"E:\Bridglabz\Stock_Account_Management\Stock_Account_Management\InventoryManagement\InventoryOfStocks.json"; //@ define path
        static void Main(string[] args)
        {
            String Choice = "";
            InventoryManager main = new InventoryManager();         
            Console.WriteLine("Enter 'add' if u want to ADD an ACCOUNT");
            Console.WriteLine("Enter 'buy' if u want to BUY some shares");
            Console.WriteLine("Enter 'valueof' if u want to Display SHARES of an ACCOUNT");
            Console.WriteLine("Enter 'printreport' if u want to Display SHARES of ALL ACCOUNTS");
            Console.WriteLine("Enter stop to exit!");
            while (Choice != "stop")
            {
                Choice = Console.ReadLine().ToLower();
                switch (Choice)
                {                   
                  
                   case "add":
                               main.addAccount(Inventory_Json);
                               break;

                    case "valueof":
                               main.valueOf(Inventory_Json);
                               break;

                    case "buy":
                               main.buy();
                               break;

                    case "sell":
                               main.sell();
                               break;

                    case "printreport":
                               main.printReport(Inventory_Json);
                               break;
                }
            }

        }
    }
}
