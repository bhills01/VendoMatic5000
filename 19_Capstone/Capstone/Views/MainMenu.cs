using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Views
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class MainMenu : CLIMenu
    {
        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public MainMenu(VendingMachine newVendingMachine) : base(newVendingMachine)
        {
            Vendo_Matic_800 = newVendingMachine;
            this.Title = "***********  Main Menu  ***********";
            this.menuOptions.Add("1", "Display Vending Machine Items");
            this.menuOptions.Add("2", "Purchase");
            this.menuOptions.Add("E", "Exit");
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
                    ItemsMenu itemsMenu = new ItemsMenu(Vendo_Matic_800);
                    itemsMenu.Run();
                    return true;
                case "2":
                    PurchaseMenu purchaseMenu = new PurchaseMenu(Vendo_Matic_800);
                    purchaseMenu.Run();
                    return true;
                case "E":
                    Console.Clear();
                    Console.WriteLine($"*****  Thank you for using the Vendo-Matic-800!!!  *****");
                    Console.WriteLine();
                    Vendo_Matic_800.quarters = 0;
                    Vendo_Matic_800.dimes = 0;
                    Vendo_Matic_800.nickels = 0;
                    Vendo_Matic_800.EndVending();
                    string changeString = $"Please take your change: {Vendo_Matic_800.quarters} Quarters, {Vendo_Matic_800.dimes} Dimes, {Vendo_Matic_800.nickels} Nickels.";
                    Console.WriteLine(new string('=', changeString.Length));
                    Console.WriteLine(changeString);
                    Console.WriteLine(new string('=', changeString.Length));
                    Console.WriteLine();
                    Console.WriteLine("Press [ENTER] to continue!");
                    Console.ReadLine();
                    Environment.Exit(0);
                    return false;
                case "4":
                    Vendo_Matic_800.GenerateSalesReport();
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
                Console.WriteLine("\r\nPlease make a selection:");
                foreach (KeyValuePair<string, string> menuItem in menuOptions)
                {
                    Console.WriteLine($"({menuItem.Key}) - {menuItem.Value}");
                }

                string choice = GetString("Selection:").ToUpper();
                if (choice == "4")
                {
                    Pause("Sales report generated!");
                    if (!ExecuteSelection(choice))
                    {
                        break;
                    }
                }
                else if (menuOptions.ContainsKey(choice))
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
