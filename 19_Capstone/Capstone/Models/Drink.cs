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
            DrinkPrice = drinkPrice;
            //Message = "Glug Glug, Yum!";
            base.Message = "Glug Glug, Yum!";

        }

        public string DrinkName { get; set; }
        public decimal DrinkPrice { get; set; }
        //public string Message { get; private set; }
    }

    // Properties



    //Methods


}
