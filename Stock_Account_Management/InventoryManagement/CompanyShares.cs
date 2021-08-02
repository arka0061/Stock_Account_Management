using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_Account_Management.InventoryManagement
{
   public class CompanyShares
    {
        public InventoryManager main = new InventoryManager();
        public string[] Symbol = new string [5]{"BMW","AUDI","MERCEDES","OREO","BROWNIE" };
        public int[] amount = new int[5] { 400,200,100,300,250};
        public int[] price = new int[5] { 50, 90, 100, 25, 30 };

    }

}
