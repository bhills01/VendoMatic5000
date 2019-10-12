using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.Views
{
    public class ItemSelection : CLIMenu
    {
        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public ItemSelection(VendingMachine newVendingMachine) : base(newVendingMachine)
        {
            Vendo_Matic_800 = newVendingMachine;

            this.Title = "***********  Item Selection  ***********";
            this.menuOptions.Add("1", "Purchase Menu");
            this.menuOptions.Add("M", "Return to Main Menu");                      

        }

        //public VendingMachine Vendo_Matic_800 { get; set; }


        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            switch (choice)
            {
                case "1":
                    PurchaseMenu purchaseMenu = new PurchaseMenu(Vendo_Matic_800);
                    purchaseMenu.Run();
                    return true;
                case "M":
                    MainMenu mainMenu = new MainMenu(Vendo_Matic_800);
                    mainMenu.Run();
                    return true;
            }
            return true;
        }


        public override void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(this.Title);
                Console.WriteLine(new string('=', this.Title.Length));
                Vendo_Matic_800.DisplayInventory();
                Console.WriteLine(new string('=', this.Title.Length));
                foreach (KeyValuePair<string, string> menuItem in menuOptions)
                {
                    Console.WriteLine($"({menuItem.Key}) - {menuItem.Value}");
                }

                Console.WriteLine(new string('=', this.Title.Length));
                Console.WriteLine($"Current Funds Available: {Vendo_Matic_800.Balance:C}");
                Console.WriteLine(new string('=', this.Title.Length));

                string choice = GetString("Selection:");

                if ((!menuOptions.ContainsKey(choice)) && (!Vendo_Matic_800.vendingStock.ContainsKey(choice)))
                {
                    Pause("Invalid Input,");
                }
                else if (!ExecuteSelection(choice))
                {
                    break;
                }
            }
        }

        protected override string GetString(string message)
        {
            while (true)
            {
                Console.Write(message + " ");
                string userInput = Console.ReadLine().Trim().ToUpper();
                if (!String.IsNullOrEmpty(userInput))
                {
                    foreach (Slots slot in Vendo_Matic_800.slotList)
                    {
                        string itemID = slot.SlotID;
                        int itemAmountAvailable = slot.Amount;
                        string itemName = Vendo_Matic_800.vendingStock[itemID].Name;
                        decimal itemPrice = Vendo_Matic_800.vendingStock[itemID].Price;


                        if (userInput == itemID && Vendo_Matic_800.Balance >= itemPrice)
                        {
                            Console.Clear();
                            Console.WriteLine(new string('=', this.Title.Length));
                            Vendo_Matic_800.Spend(itemPrice);
                            Vendo_Matic_800.Dispense(slot);
                            Console.WriteLine(new string('=', this.Title.Length));
                            if (itemAmountAvailable < 1)
                            {
                                Vendo_Matic_800.Deposit(itemPrice);
                                Pause("Please make another selection,");
                                break;
                            }
                            Pause("Thank you for your purchase,");
                            PurchaseMenu purchaseMenu = new PurchaseMenu(Vendo_Matic_800);
                            purchaseMenu.Run();
                        }
                        else if (userInput == itemID)
                        {
                            Console.Clear();
                            Vendo_Matic_800.Spend(itemPrice);
                            Pause("Tough Luck!,");
                            PurchaseMenu purchaseMenu = new PurchaseMenu(Vendo_Matic_800);
                            purchaseMenu.Run();
                        }
                    }
                    return userInput;
                }
                else
                {
                    return ("!!! Invalid input. Please enter a valid decimal number.");
                }
            }
        }
    }
}
