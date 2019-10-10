using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Models
{
    public class VendingMachine
    {
        public VendingMachine()
        {

        }

        public int InventoryCount { get; set; }
        public decimal Balance { get; set; }


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
        public List<Slots> slotList = new List<Slots>();
        public Dictionary<string, Item> vendingStock = new Dictionary<string, Item>();
        public void Load()
        {
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
                            Slots chipSlot = new Slots(itemLocation);
                            slotList.Add(chipSlot);
                            break;
                        case "Candy":
                            Candy candy = new Candy(itemName, itemPrice);
                            vendingStock.Add(itemLocation, candy);
                            Slots candySlot = new Slots(itemLocation);
                            slotList.Add(candySlot);
                            break;
                        case "Drink":
                            Drink drink = new Drink(itemName, itemPrice);
                            vendingStock.Add(itemLocation, drink);
                            Slots drinkSlot = new Slots(itemLocation);
                            slotList.Add(drinkSlot);
                            break;
                        case "Gum":
                            Gum gum = new Gum(itemName, itemPrice);
                            vendingStock.Add(itemLocation, gum);
                            Slots gumSlot = new Slots(itemLocation);
                            slotList.Add(gumSlot);
                            break;
                    }
                }
            }
        }

        public void DisplayInventory()
        {
            foreach (Slots slot in slotList)
            {
                string itemID = slot.SlotID;
                int itemAmountAvailable = slot.Amount;
                string itemName = vendingStock[itemID].Name;
                decimal itemPrice = vendingStock[itemID].Price;

                Console.WriteLine($"{itemID}|{itemName}|{itemPrice}|{itemAmountAvailable}");

            }


        }


        private void WriteLog()
        {

        }
    }
}
