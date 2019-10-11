using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.Views
{
    public class ItemsMenu : CLIMenu
    {
        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public ItemsMenu(VendingMachine newVendingMachine) : base(newVendingMachine)
        {
            Vendo_Matic_800 = newVendingMachine;

            this.Title = "*** Vending Items ***";
            this.menuOptions.Add("1", "Purchase");
            this.menuOptions.Add("M", "Return to Main Menu");                      

        }

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
                    PurchaseMenu newPurchaseMenu = new PurchaseMenu(Vendo_Matic_800);
                    newPurchaseMenu.Run();
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
                    Console.WriteLine($"{menuItem.Key} - {menuItem.Value}");
                }

                string choice = GetString("Selection:").ToUpper();

                if (menuOptions.ContainsKey(choice))
                {
                    if (!ExecuteSelection(choice))
                    {
                        //Console.WriteLine("Please choose (1) or (M)!");
                        //Pause("Press [ENTER] to continue.");
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

