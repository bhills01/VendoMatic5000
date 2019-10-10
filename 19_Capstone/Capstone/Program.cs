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

            Candy newCandy = new Candy("name", 1.00M, "message");
            Console.WriteLine(newCandy.Message);
            Console.ReadLine();

        }
    }
}
