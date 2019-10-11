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
            this.menuOptions.Add("M", "Main Menu");
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
                    Console.Clear();
                    Console.WriteLine($"Your current balance is {Vendo_Matic_800.Balance:C}");
                    decimal moneyFeed = GetDecimal("How much money would you like to deposit ?: ");
                    Vendo_Matic_800.Deposit(moneyFeed);

                    Console.Clear();
                    Console.WriteLine($"You have {Vendo_Matic_800.Balance:C} available!");
                    Console.WriteLine("Press [ENTER] to return to the Purchase Menu");
                    Console.ReadLine();             
                    return true;

                case "2":
                    ItemSelection itemSelection = new ItemSelection(Vendo_Matic_800);
                    itemSelection.Run();
                    return true;
                case "F":
                    Console.Clear();
                    Console.WriteLine($"Thank you for using the Vendo-Matic-800!!!");
                    Console.WriteLine();
                    int quarters = 0;
                    int dimes = 0;
                    int nickels = 0;
                    if (Vendo_Matic_800.Balance >= .25m)
                    {
                        quarters = (int)(Vendo_Matic_800.Balance * 100) / 25;
                        Vendo_Matic_800.Balance = Vendo_Matic_800.Balance % .25m;
                    }
                    if (Vendo_Matic_800.Balance >= .10m)
                    {
                        dimes = (int)(Vendo_Matic_800.Balance * 100) / 10;
                        Vendo_Matic_800.Balance = Vendo_Matic_800.Balance % .10m;
                    }
                    if (Vendo_Matic_800.Balance >= .05m)
                    {
                        nickels = (int)(Vendo_Matic_800.Balance * 100) / 5;
                    }
                    Console.WriteLine($"Please take your change: {quarters} Quarters, {dimes} Dimes, {nickels} Nickels.");
                    Vendo_Matic_800.Balance = 0;
                    Console.WriteLine();
                    Console.WriteLine("Press [ENTER] to continue!");
                    Console.ReadLine();

                    MainMenu mainMenu = new MainMenu(Vendo_Matic_800);
                    mainMenu.Run();
                    return true;
                case "M":
                    MainMenu mainMenu2 = new MainMenu(Vendo_Matic_800);
                    mainMenu2.Run();
                    return true;

                    //return false;
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
                Console.WriteLine("\r\nPlease make a selection:");
                foreach (KeyValuePair<string, string> menuItem in menuOptions)
                {
                    Console.WriteLine($"({menuItem.Key}) - {menuItem.Value}");
                }

                Console.WriteLine(new string('=', this.Title.Length));
                Console.WriteLine($"Current Funds Available: {Vendo_Matic_800.Balance:C}");
                Console.WriteLine(new string('=', this.Title.Length));


                string choice = GetString("Selection:").ToUpper();

                if (menuOptions.ContainsKey(choice))
                {
                    if (!ExecuteSelection(choice))
                    {
                        break;
                    }
                }
                else
                {
                    Pause("Invalid Selection,");
                }
            }
        }
    }
}
