using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Candy : Item
    {
        public Candy(string candyName, decimal candyPrice, string candyMessage): base(candyName, candyPrice)
        {
            //Contructor
            CandyName = candyName;
            CandyPrice = candyPrice;//Test Price hard coded. Will replace with StreamReader eventually
            Message = "Crunch, Crunch, Yum!";
        }

        // Properties
        public string CandyName { get; set; }
        public decimal CandyPrice { get; set; }

        //Methods



    }
}
