using Stock_Account_Management.InventoryManagement;
using System;
namespace Stock_Account_Management
{
    class Program
    {
       const String Inventory_Json = @"E:\Bridglabz\Stock_Account_Management\Stock_Account_Management\InventoryManagement\Inventory.json"; //@ define path
        static void Main(string[] args)
        {
            String Choice = "";
            InventoryManager main = new InventoryManager();         
            Console.WriteLine("Enter 'disp' if u want to Display the items");
            while (Choice != "stop")
            {
                Choice = Console.ReadLine().ToLower();
                switch (Choice)
                {                   
                   case "disp":
                               main.Display(Inventory_Json);
                                break;           
                }
            }

        }
    }
}
