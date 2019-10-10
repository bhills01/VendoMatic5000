using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Drink : Item
    {
        public Drink(string drinkName, decimal drinkPrice) : base(drinkName, drinkPrice)
        {
            DrinkName = drinkName;
            DrinkPrice = drinkPrice;//Test Price hard coded. Will replace with StreamReader eventually
            Message = "Glug Glug, Yum!";
        }

        public string DrinkName { get; set; }
        public decimal DrinkPrice { get; set; }
        public string Message { get; private set; }
    }

    // Properties



    //Methods


}
