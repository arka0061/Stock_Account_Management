using System;
using Newtonsoft.Json;
using Stock_Account_Management;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Stock_Account_Management.InventoryManagement
{
    public class InventoryManager
    {

        public void AddAccount(String filepath)
        {
            string jsonData = File.ReadAllText(filepath);
            InventoryModel jsonObjectArray = JsonConvert.DeserializeObject<InventoryModel>(jsonData);
            List<Stock> stock = jsonObjectArray.StockList;
            Stock obj = new Stock();
            Console.WriteLine("Please Enter AccountName:");
            obj.accountname = Console.ReadLine();
            obj.stockName = "BMW";
            obj.numberOfShares = 50;
            obj.sharePrice = 50;
            stock.Add(obj);
            InventoryManager.WriteToFile(jsonObjectArray);
            Console.WriteLine("Account Created!");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Enter your Choice!");

        }
        public void ValueOf(String filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    string jsonData = File.ReadAllText(filepath);
                    int counter = 0;
                    InventoryModel jsonObjectArray = JsonConvert.DeserializeObject<InventoryModel>(jsonData);
                    List<Stock> stock = jsonObjectArray.StockList;
                    double totalValue = 0;
                    Console.WriteLine("Enter Account name :");
                    String Name = Console.ReadLine();
                    Console.WriteLine("AccountName" + "\t" + "StockName" + "\t" + "Shares" + "\t" + "Price" + "\t" + "Value");
                    foreach (var item in stock)
                    {

                        if (item.accountname == Name)
                        {
                            counter++;
                            totalValue = totalValue + (item.numberOfShares * item.sharePrice);
                            Console.WriteLine("{0}" + "\t" + "\t" + "{1}" + "\t" + "\t" + "{2}" + "\t" + "{3}" + "\t" + "{4}", item.accountname, item.stockName, item.numberOfShares, item.sharePrice, item.numberOfShares * item.sharePrice);
                            Console.WriteLine("------------------------------------------------------------------");
                            Console.WriteLine("Enter your Choice!");
                        }
                        else
                        {
                            if (counter == stock.Count)
                                Console.WriteLine("Account Not Found!");
                            Console.WriteLine("------------------------------------------------------------------");
                            Console.WriteLine("Enter your Choice!");
                        }

                    }
                    Console.WriteLine("Total Value of all Shares :" + totalValue);
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine("Enter your Choice!");
                }
                else
                {
                    Console.WriteLine("File Does not Exists");
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine("Enter your Choice!");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Buy()
        {
            Stock obj = new Stock();
            Program pro = new Program();
            CompanyShares cmp = new CompanyShares();
            string[] symbol = cmp.Symbol;
            int[] amount = cmp.amount;
            int[] pice = cmp.price;
            string jsonData = File.ReadAllText(Program.Inventory_Json);
            int counter = 0;
            int counter2 = 0;
            String SymbolName = "";
            int amountOfShare = 0;
            int i;
            InventoryModel jsonObjectArray = JsonConvert.DeserializeObject<InventoryModel>(jsonData);
            List<Stock> stock = jsonObjectArray.StockList;
            Console.WriteLine("Enter Account name :");
            String Name = Console.ReadLine();
            Console.WriteLine("Enter Symbol :");
            SymbolName = Console.ReadLine();
            foreach (var item in stock.ToArray())
            {
                counter++;
                if (item.accountname == Name && item.stockName == SymbolName)
                {
                    Console.WriteLine("Enter number of shares to ADD");
                    amountOfShare = Convert.ToInt32(Console.ReadLine());
                    item.numberOfShares = item.numberOfShares + amountOfShare;
                    int TextIndex = Array.FindIndex(symbol, m => m == SymbolName);
                    if (amountOfShare <= amount[TextIndex])
                    {
                        obj.numberOfShares = amountOfShare;
                        obj.sharePrice = cmp.price[TextIndex];
                        stock.Add(obj);
                        Console.WriteLine("Shares Added!");
                        Console.WriteLine("------------------------------------------------------------------");
                        Console.WriteLine("Enter your Choice!");

                        break;
                    }
                    else
                    {

                        Console.WriteLine("Shares not avaiable");
                        Console.WriteLine("------------------------------------------------------------------");
                        Console.WriteLine("Enter your Choice!");
                        break;
                    }
                }
                else
                {

                    if (counter == stock.Count)
                    {
                        Console.WriteLine("User First time buyng new stock :");
                        Console.WriteLine("Enter Account name :");
                        string name = Console.ReadLine();
                        foreach (var items in stock)
                        {
                            counter2++;
                            if (items.accountname == name)
                            {
                                obj.accountname = name;
                                Console.WriteLine("Enter new Stock or Symbol :");
                                obj.stockName = SymbolName;
                                int TextIndex = Array.FindIndex(symbol, m => m == SymbolName);
                                Console.WriteLine("Enter Amount of Share");
                                amountOfShare = Convert.ToInt32(Console.ReadLine());
                                if (amountOfShare <= amount[TextIndex])
                                {
                                    obj.numberOfShares = amountOfShare;
                                    obj.sharePrice = cmp.price[TextIndex];
                                    stock.Add(obj);
                                    Console.WriteLine("Shares Added!");
                                    Console.WriteLine("------------------------------------------------------------------");
                                    Console.WriteLine("Enter your Choice!");

                                    break;
                                }
                                else
                                {

                                    Console.WriteLine("Shares not avaiable");
                                    Console.WriteLine("------------------------------------------------------------------");
                                    Console.WriteLine("Enter your Choice!");

                                    break;
                                }
                            }
                            else
                            {
                                if (counter2 == stock.Count)
                                    Console.WriteLine("Account Doesnt Exist!");
                                Console.WriteLine("------------------------------------------------------------------");
                                Console.WriteLine("Enter your Choice!");


                            }
                        }
                    }
                }
            }
            InventoryManager.WriteToFile(jsonObjectArray);
        }

        public void Sell()
        {
            Stock obj = new Stock();
            string jsonData = File.ReadAllText(Program.Inventory_Json);
            int counter = 0;
            String SymbolName = "";
            int amountOfShare = 0;
            int i;
            InventoryModel jsonObjectArray = JsonConvert.DeserializeObject<InventoryModel>(jsonData);
            List<Stock> stock = jsonObjectArray.StockList;
            Console.WriteLine("Enter Account name :");
            String Name = Console.ReadLine();
            Console.WriteLine("Enter symbol of share to delete");
            SymbolName = Console.ReadLine();
            foreach (var item in stock)
            {
                counter++;
                if (item.accountname == Name && item.stockName == SymbolName)
                {
                    Console.WriteLine("Enter number of shares to delete");
                    amountOfShare = Convert.ToInt32(Console.ReadLine());
                    item.numberOfShares = item.numberOfShares - amountOfShare;
                    Console.WriteLine("Shares Sold!");
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine("Enter your Choice!");

                    break;
                }
                else
                {
                    if (counter == stock.Count)
                        Console.WriteLine("Account Doesnt Exist or Symbol Doesnt Exist!");
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine("Enter your Choice!");

                }
            }

            InventoryManager.WriteToFile(jsonObjectArray);
        }
        public static void WriteToFile(InventoryModel inventory)
        {
            string jsonConvrsion = JsonConvert.SerializeObject(inventory);
            System.IO.File.WriteAllText(@"E:\Bridglabz\Stock_Account_Management\Stock_Account_Management\InventoryManagement\InventoryOfStocks.json", jsonConvrsion);
        }

        public void PrintReport(String filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    string jsonData = File.ReadAllText(filepath);
                    int counter = 0;
                    InventoryModel jsonObjectArray = JsonConvert.DeserializeObject<InventoryModel>(jsonData);
                    List<Stock> stock = jsonObjectArray.StockList;
                    double totalValue = 0;                   
                    Console.WriteLine("AccountName" + "\t" + "StockName" + "\t" + "Shares" + "\t" + "Price" + "\t" + "Value");
                    foreach (var item in stock)
                    {
                        counter++;
                        totalValue = totalValue + (item.numberOfShares * item.sharePrice);
                        Console.WriteLine("{0}" + "\t" + "\t" + "{1}" + "\t" + "\t" + "{2}" + "\t" + "{3}" + "\t" + "{4}", item.accountname, item.stockName, item.numberOfShares, item.sharePrice, item.numberOfShares * item.sharePrice);
                    }                  
                    Console.WriteLine("Total Value of all Shares :" + totalValue);
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine("Enter your Choice!");
                    }
                    else
                    {
                    Console.WriteLine("File Does not Exists");
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine("Enter your Choice!");
                    }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}



