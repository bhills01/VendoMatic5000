using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Models
{
    public class VendingMacine
    {
        public VendingMacine()
        {

        }

        public int InventoryCount { get; set; }
        public decimal Balance { get; set; }
        public Slots TheSlots { get; set; }

        //public List<string> vendingItems = new List<string>();
        public void Deposit (decimal depositAmount)
        {

        }

        public void Spend(decimal amountSpent)
        {

        }

        public string Dispense(string purchaseMessage)
        {
            return "";
        }

        public void Load()
        {
            Dictionary<string, Item> vendingStock = new Dictionary<string, Item>();
            string filePath = @"..\..\..\..\vendingmachine.csv";
            using (StreamReader itemString = new StreamReader(filePath))
            {
                while (!itemString.EndOfStream)
                {
                    string itemLines = itemString.ReadLine();
                    string[] itemArray = itemLines.Split("|");
                    string itemLocation = itemArray[0];
                    string itemName = itemArray[1];
                    decimal itemPrice = decimal.Parse(itemArray[2]);
                    string itemType = itemArray[3];


                    switch (itemType)
                    {
                        case "Chip":
                            Chips chips = new Chips(itemName, itemPrice);
                            vendingStock.Add(itemLocation, chips);
                            break;
                        case "Candy":
                            Candy candy = new Candy(itemName, itemPrice);
                            vendingStock.Add(itemLocation, candy);
                            break;
                        case "Drink":
                            Drink drink = new Drink(itemName, itemPrice);
                            vendingStock.Add(itemLocation, drink);
                            break;
                        case "Gum":
                            Gum gum = new Gum(itemName, itemPrice);
                            vendingStock.Add(itemLocation, gum);
                            break;
                    }
                }
            }
        }

        private void WriteLog()
        {

        }
    }
}
