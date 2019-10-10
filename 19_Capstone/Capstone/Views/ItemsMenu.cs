using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Views
{
    public class ItemsMenu : CLIMenu
    {
        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public ItemsMenu() : base()
        {
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
                    Console.WriteLine("**Will Take You to Purchase Menu**");
                    Pause("Press any key");
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
                Console.WriteLine("Slot | Item Name | Price | Quantity");
                Console.WriteLine("Slot | Item Name | Price | Quantity");
                Console.WriteLine("Slot | Item Name | Price | Quantity");
                Console.WriteLine("Slot | Item Name | Price | Quantity");
                Console.WriteLine("Slot | Item Name | Price | Quantity");
                Console.WriteLine("Slot | Item Name | Price | Quantity");
                Console.WriteLine("Slot | Item Name | Price | Quantity");
                Console.WriteLine("Slot | Item Name | Price | Quantity");
                Console.WriteLine("Slot | Item Name | Price | Quantity");
                Console.WriteLine("Slot | Item Name | Price | Quantity");
                Console.WriteLine("Slot | Item Name | Price | Quantity");
                Console.WriteLine("Slot | Item Name | Price | Quantity");
                Console.WriteLine("Slot | Item Name | Price | Quantity");
                foreach (KeyValuePair<string, string> menuItem in menuOptions)
                {
                    Console.WriteLine($"{menuItem.Key} - {menuItem.Value}");
                }

                string choice = GetString("Selection:").ToUpper();

                if (menuOptions.ContainsKey(choice))
                {
                    if (choice == "M")
                    {
                        Console.WriteLine("**Will Take You to Main Menu*");
                    }
                    if (!ExecuteSelection(choice))
                    {
                        Console.WriteLine("Please Choose (1) or (M)"); ;
                    }
                }
                Console.ReadLine();
            }
        }

    }
}
