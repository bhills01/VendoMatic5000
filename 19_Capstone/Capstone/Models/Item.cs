using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    abstract public class Item
    {
        public Item(string name, decimal price, string message)
        {
            Name = name;
            Price = price;
            Message = message;

        }

        // Properties

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Message { get; set; }
        

        // Methods



    }
}
