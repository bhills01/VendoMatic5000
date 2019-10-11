﻿using System;
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

            Balance += depositAmount;
        }

        public void Spend(decimal amountSpent)
        {
            if (amountSpent > Balance)
            {
                Console.WriteLine("Insufficient funds available. Please feed more money into the machine!!");
                return;
            }
            Balance -= amountSpent;
        }

        public void Dispense(Slots slotID)
        {
            if (slotID.Amount >= 1)
            {
                slotID.Amount--;
                Console.WriteLine($"{vendingStock[slotID.SlotID].Message}");
            }
            else
            {
                Console.WriteLine($"SOLD OUT!!!");
            }
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
                string soldOut = "";
                soldOut = (itemAmountAvailable >= 1) ? $"{itemAmountAvailable}" : "SOLD OUT!!!";
                Console.WriteLine($"{itemID}|{itemName}|{itemPrice:C}|{soldOut}");

            }


        }

        virtual public void EndVending()
        {
            Console.Clear();
            Console.WriteLine($"Thank you for using the Vendo-Matic-800!!!");
            Console.WriteLine();
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            if (Balance >= .25m)
            {
                quarters = (int)(Balance * 100) / 25;
                Balance = Balance % .25m;
            }
            if (Balance >= .10m)
            {
                dimes = (int)(Balance * 100) / 10;
                Balance = Balance % .10m;
            }
            if (Balance >= .05m)
            {
                nickels = (int)(Balance * 100) / 5;
            }
            Console.WriteLine($"Please take your change: {quarters} Quarters, {dimes} Dimes, {nickels} Nickels.");
            Balance -= Balance;
            Console.WriteLine();
            Console.WriteLine("Press [ENTER] to continue!");
            Console.ReadLine();
            Environment.Exit(0);
        }

        private void WriteLog()
        {

        }
    }
}
