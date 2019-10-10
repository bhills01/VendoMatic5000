using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    abstract public class Item
    {
        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        // Properties

        public string Name { get; set; }
        public decimal Price { get; set; }
        

        // Methods



    }
}
