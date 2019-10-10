using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Candy : Item
    {
        public Candy(string candyName, decimal candyPrice): base(candyName, candyPrice)
        {
            CandyName = candyName;
            CandyPrice = candyPrice;//Test Price hard coded. Will replace with StreamReader eventually
            Message = "Munch Munch, Yum!";
        }

        // Properties
        public string CandyName { get; set; }
        public decimal CandyPrice { get; set; }
        public string Message { get; private set; }
        //Methods



    }
}
