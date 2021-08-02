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
        public void Display(String filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    string jsonData = File.ReadAllText(filepath);
                    double totalValue = 0;
                    InventoryModel jsonObjectArray = JsonConvert.DeserializeObject<InventoryModel>(jsonData);
                    Console.WriteLine("StockName" + "\t" + "Shares" + "\t" + "Price" + "\t" + "Value");
                    List<Stock> stock = jsonObjectArray.StockList;
                    foreach (var item in stock)
                    {
                        totalValue = totalValue + (item.numberOfShares * item.sharePrice);
                        Console.WriteLine( "{0}" + "\t" + "\t"+"{1}" + "\t" + "{2}" + "\t" + "{3}", item.stockName, item.numberOfShares, item.sharePrice, item.numberOfShares*item.sharePrice);
                    }
                    Console.WriteLine("Total Value of all Shares :" + totalValue);
                    Console.WriteLine("-------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("File Does not Exists");
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

