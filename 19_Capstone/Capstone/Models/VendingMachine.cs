using Capstone.Views;
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

        /// <summary>
        /// When given a deposit amount, will determine if the number is small enough not to break the program.
        /// Then determines if the number is a positive whole decimal.
        /// Once determined, the Balance property is updated with the deposit amount.
        /// </summary>
        /// <param name="depositAmount"></param>
        /// <returns></returns>
        public bool Deposit (decimal depositAmount)
        {
            if (depositAmount > 10000000)
            {
                return false;
            }
            else if ((depositAmount >= (decimal)0.00) && (depositAmount % (decimal)1 == 0))
            {
                Balance += depositAmount;
                WriteLog("FEED MONEY", depositAmount);
                return true;
            }
            else
            {
                return false;
            }

        }

        decimal totalSpent = 0;

        /// <summary>
        /// When given a decimal, will determine if there is enough left in the Balance property to perform the action.
        /// If true, the amountSpent decimal will be subracted from the Balance property.
        /// If false, a warning will appear onscreen.
        /// The amountApent will also be added to totalSpent for the purpose of writing the sales report.
        /// </summary>
        /// <param name="amountSpent"></param>
        public void Spend(decimal amountSpent)
        {
            totalSpent += amountSpent;
            if (amountSpent > Balance)
            {
                string insufficientFundsWarning = "Insufficient funds available. Please feed more money into the machine!!";
                Console.WriteLine(new string('=', insufficientFundsWarning.Length));
                Console.WriteLine(insufficientFundsWarning);
                Console.WriteLine(new string('=', insufficientFundsWarning.Length));
                Console.WriteLine();

                return;
            }
            Balance -= amountSpent;
        }

        /// <summary>
        /// When given a slot ID, as long as the Slot.Amount is 1 or more, the Slot.Amount will decrement 1.
        /// A log will also be written.
        /// </summary>
        /// <param name="slotID"></param>
        public void Dispense(Slots slotID)
        {
            if (slotID.Amount >= 1)
            {
                decimal startingBalance = (Balance + (vendingStock[slotID.SlotID].Price));
                WriteLog(vendingStock[slotID.SlotID].Name, (startingBalance));
                slotID.Amount--;
            }
            else
            {
                return;
            }
        }

        public List<Slots> slotList = new List<Slots>();
        public Dictionary<string, Item> vendingStock = new Dictionary<string, Item>();

        /// <summary>
        /// The vendingmachine.csv is read line by line and applied to an array seperated by "|".
        /// The resulting strings of the idexes in the array are applied to a corresponding dictionary and/or list.
        /// </summary>
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


        /// <summary>
        /// Displays itemID, itemName, itemPrice, and itemAmountAvailable (unless it's sold out).
        /// </summary>
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
                Console.WriteLine($"{itemID}|{itemName,-22}|{itemPrice:C}| QTY: {soldOut}");

            }
        }

        public int quarters = 0;
        public int dimes = 0;
        public int nickels = 0; 

        /// <summary>
        /// Uses math to determine how many quarters, dimes, and nickels are returned to the user.
        /// Zeros out balance.
        /// </summary>
        virtual public void EndVending()
        {
            decimal beginningBalance = Balance;
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
            Balance -= Balance;
            WriteLog("GIVE CHANGE", beginningBalance);
        }

        /// <summary>
        /// Given string of function type (deposit, sale, end vending) and a decimal of the transaction writes a line to the Log.txt.
        /// </summary>
        /// <param name="functionLogged"></param>
        /// <param name="transactionLogged"></param>
        protected void WriteLog(string functionLogged, decimal transactionLogged)
        {
            DateTime currentDateTime = new DateTime();
            currentDateTime = DateTime.Now;
            string destinationFilePath = @"..\..\..\..\Log.txt";
            using (StreamWriter writeLog = new StreamWriter(destinationFilePath, true))
            {
                writeLog.WriteLine($"{currentDateTime,-23}||{"",-6}{functionLogged,-23}{"||",-8}{transactionLogged,-11:C}{"||",-12}{Balance:C}");
            }
        }

        /// <summary>
        /// Writes itemID, itemName, and amount sold to SalesReport.txt.
        /// As well as writes the totalSpent at the end of the report.
        /// </summary>
        public void GenerateSalesReport()
        {
            string destinationFilePath = @"..\..\..\..\SalesReport.txt";

            using (StreamWriter writeLog = new StreamWriter(destinationFilePath, false))
            {
                foreach (Slots slot in slotList)
                {
                    string itemID = slot.SlotID;
                    string itemName = vendingStock[itemID].Name;
                    int itemAmountSold = 5 - slot.Amount;
                    writeLog.WriteLine($"{itemName}|{itemAmountSold}");
                }
                writeLog.WriteLine();
                writeLog.WriteLine($"Total Sales: {totalSpent:C}");

            }
        }
    }
}
