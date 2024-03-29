﻿using Capstone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Views
{
    /// <summary>
    /// *CLIMenu* is an abstract class from which all other menu classes are derived.  To implement a menu, 
    /// you need to:
    ///     * Derived from CLIMenu
    ///     * Implement a constructor which builds the *menuOptions* dictionary.
    ///     * Override ExecuteSelection to handle weach of the user's selections.
    /// 
    /// </summary>
    public abstract class CLIMenu
    {
        /*** 
         * Model Data that this menu system needs to operate on goes here.
         ***/

        /// <summary>
        /// This is where every sub-menu puts its options for display to the user.
        /// </summary>
        protected Dictionary<string, string> menuOptions;
        public VendingMachine Vendo_Matic_800 { get; set; }
        /// <summary>
        /// The Title of this menu
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Constructor - pass in model data here
        /// </summary>
        public CLIMenu(VendingMachine newVendingMachine)
        {
            this.menuOptions = new Dictionary<string, string>();
            Vendo_Matic_800 = newVendingMachine;
        }



        /// <summary>
        /// Run starts the menu loop
        /// </summary>
        virtual public void Run()
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

                if (menuOptions.ContainsKey(choice))
                {
                    if (!ExecuteSelection(choice))
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Given a valid menu selection, runs the approriate code to do what the user is asking for.
        /// </summary>
        /// <param name="choice">The menu option (key) selected by the user</param>
        /// <returns>True to keep executing the menu (loop), False to exit this menu (break)</returns>
        abstract protected bool ExecuteSelection(string choice);

        #region User Input Helper Methods
        /// <summary>
        /// This continually prompts the user until they enter a valid integer.
        /// </summary>
        /// <param name="message">The string to prompt the user with</param>
        /// <returns>A valid integer entered by the user</returns>
        protected int GetInteger(string message)
        {
            int resultValue = 0;
            while (true)
            {
                Console.Write(message + " ");
                string userInput = Console.ReadLine().Trim();
                if (int.TryParse(userInput, out resultValue))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("!!! Invalid input. Please enter a valid whole number.");
                }
            }
            return resultValue;
        }

        /// <summary>
        /// This continually prompts the user until they enter a valid double.
        /// </summary>
        /// <param name="message">The string to prompt the user with</param>
        /// <returns>A valid double entered by the user</returns>
        protected double GetDouble(string message)
        {
            double resultValue = 0;
            while (true)
            {
                Console.Write(message + " ");
                string userInput = Console.ReadLine().Trim();
                if (double.TryParse(userInput, out resultValue))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("!!! Invalid input. Please enter a valid decimal number.");
                }
            }
            return resultValue;
        }
        protected decimal GetDecimal(string message)
        {
            decimal resultValue = 0;
            while (true)
            {
                Console.Write(message + " ");
                string userInput = Console.ReadLine().Trim();
                if (decimal.TryParse(userInput, out resultValue))
                {
                    break;
                }
                if (userInput == "")
                {
                    PurchaseMenu purchaseMenu = new PurchaseMenu(Vendo_Matic_800);
                    purchaseMenu.Run();
                }
                else
                {
                    Console.WriteLine("!!! Invalid input !!! ");
                }
            }
            return resultValue;
        }

        /// <summary>
        /// This continually prompts the user until they enter a valid bool.
        /// </summary>
        /// <param name="message">The string to prompt the user with</param>
        /// <returns>True or false.  The user can type Y or true for true values, N or false for false values.</returns>
        protected bool GetBool(string message)
        {
            bool resultValue = false;
            while (true)
            {
                Console.Write(message + " ");
                string userInput = Console.ReadLine().Trim();
                if (userInput.ToUpper() == "Y")
                {
                    resultValue = true;
                    break;
                }
                else if (userInput == "N")
                {
                    resultValue = false;
                    break;
                }
                else if (bool.TryParse(userInput, out resultValue))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("!!! Invalid input. Please enter [True, False, Y or N].");
                }
            }
            return resultValue;
        }

        /// <summary>
        /// This continually prompts the user until they enter a valid string (1 or more characters).
        /// </summary>
        /// <param name="message">The string to prompt the user with</param>
        /// <returns>String entered by the user</returns>
        virtual protected string GetString(string message)
        {
            while (true)
            {
                Console.Write(message + " ");
                string userInput = Console.ReadLine().Trim();
                if (!String.IsNullOrEmpty(userInput))
                {
                    return userInput;
                }
                else
                {
                    Pause("You did not enter a selection,");
                }
            }
        }

        /// <summary>
        /// Shows a message to the user and waits for the user to hit return
        /// </summary>
        /// <param name="message">Displays a message to the user and then waits for them to hit Return.</param>
        protected void Pause(string message)
        {
            Console.Write(message + " Press Enter to continue.");
            Console.ReadLine();
        }
        #endregion
        protected void WriteLog(string functionLogged, decimal transactionLogged)
        {
            DateTime currentDateTime = new DateTime();
            currentDateTime = DateTime.Now;
            string destinationFilePath = @"..\..\..\..\Log.txt";
            using (StreamWriter writeLog = new StreamWriter(destinationFilePath, true))
            {
                writeLog.WriteLine($"{currentDateTime,-23}||{"" ,-6}{functionLogged ,-23}{"||",-8}{transactionLogged,-11:C}{"||",-12}{Vendo_Matic_800.Balance:C}");
            }

        }
    }
}
