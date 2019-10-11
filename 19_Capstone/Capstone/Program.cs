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

            // Testing Display Inventory List

            //VendingMachine newMachine = new VendingMachine();
            //newMachine.Load();
            ////for (int i = 0; i < newMachine.vendingStock.Count; i++)
            //newMachine.DisplayInventory();

            //Console.ReadLine();

            // Testing Slot fucntionality

            //VendingMachine newMachine = new VendingMachine();
            //newMachine.Load();


            //foreach (Slots slot in newMachine.slotList)
            //{
            //    Console.WriteLine($"{slot.Amount}{slot.SlotID} ");
            //}

            //Testing Dispense
            //VendingMachine newVend = new VendingMachine();
            //newVend.Load();

            //newVend.Dispense("A1")

            //Console.ReadLine();

        }
    }
}
