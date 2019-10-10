using Capstone.Models;
using Capstone.Views;
using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Starts the Main Menu Running

            //MainMenu mainMenu = new MainMenu();
            //mainMenu.Run();


            //Testing Candy Class Creation

            //Candy newCandy = new Candy("candy", 1.00M);
            //Chips newChips = new Chips("chips", 1.00M);
            //Gum newGum = new Gum("gum", 1.00M);
            //Drink newDrink = new Drink("drink", 1.00M);
            //Console.WriteLine(newCandy.Message);
            //Console.WriteLine(newChips.Message);
            //Console.WriteLine(newGum.Message);
            //Console.WriteLine(newDrink.Message);
            //Console.WriteLine(newCandy.Price);
            //Console.WriteLine(newChips.Price);
            //Console.WriteLine(newGum.Price);
            //Console.WriteLine(newDrink.Price);
            //Console.WriteLine(newCandy.Name);
            //Console.WriteLine(newChips.Name);
            //Console.WriteLine(newGum.Name);
            //Console.WriteLine(newDrink.Name);
            //Console.ReadLine();

            // Testing Load Feature

            VendingMacine loadTest = new VendingMacine();
            loadTest.Load();

            foreach (string item in loadTest.itemLines)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();

        }
    }
}
