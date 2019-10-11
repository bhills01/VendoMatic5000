using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Views
{
    public class PurchaseMenu : CLIMenu
    {
        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public PurchaseMenu(VendingMachine newVendingMachine) : base(newVendingMachine)
        {
            Vendo_Matic_800 = newVendingMachine;

            this.Title = "*** Purchase Menu ***";
            this.menuOptions.Add("1", "Feed Money");
            this.menuOptions.Add("2", "Select Product");
            this.menuOptions.Add("F", "Finish Transaction");
        }

        public VendingMachine Vendo_Matic_800 { get; set; }


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
                    Console.Clear();
                    Console.WriteLine($"Your current balance is {Vendo_Matic_800.Balance}");
                    Console.Write("How much money would you like to deposit?:");
                    decimal moneyFeed = decimal.Parse(Console.ReadLine());
                    Vendo_Matic_800.Deposit(moneyFeed);

                    Console.Clear();
                    Console.WriteLine($"You have {Vendo_Matic_800.Balance} available!");
                    Console.WriteLine("Press [ENTER] to return to the Purchase Menu");
                    Console.ReadLine();             
                    return true;

                case "2":
                    ItemSelection itemSelection = new ItemSelection(Vendo_Matic_800);
                    itemSelection.Run();
                    return true;
                case "F":
                    Console.WriteLine("You selected option 1");
                    Pause("Press any key");
                    return true;
            }
            return true;
        }
        public override void Run()
        {
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(this.Title);
                    Console.WriteLine(new string('=', this.Title.Length));
                    Console.WriteLine("\r\nPlease make a selection:");
                    foreach (KeyValuePair<string, string> menuItem in menuOptions)
                    {
                        Console.WriteLine($"({menuItem.Key}) - {menuItem.Value}");
                    }

                    Console.WriteLine(new string('=', this.Title.Length));
                    Console.WriteLine($"Current Funds Available: {Vendo_Matic_800.Balance}");
                    Console.WriteLine(new string('=', this.Title.Length));


                    string choice = GetString("Selection:").ToUpper();

                    if (menuOptions.ContainsKey(choice))
                    {
                        if (choice == "E")
                        {
                            break;
                        }
                        if (!ExecuteSelection(choice))
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
