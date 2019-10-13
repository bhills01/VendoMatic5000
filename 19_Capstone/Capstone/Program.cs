using Capstone.Models;
using Capstone.Views;
using System;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Starts the Main Menu Running

            VendingMachine Vendo_Matic_800 = new VendingMachine();
            Vendo_Matic_800.Load();

            MainMenu mainMenu = new MainMenu(Vendo_Matic_800);
            mainMenu.Run();

        }
    }
}
