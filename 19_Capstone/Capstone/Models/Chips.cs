using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Chips : Item
    {
        //Contructor
        public Chips(string chipsName, decimal chipsPrice) : base(chipsName, chipsPrice)
        {
            ChipsName = chipsName;
            ChipsPrice = chipsPrice;//Test Price hard coded. Will replace with StreamReader eventually
            //Message = "Crunch Crunch, Yum!";
            base.Message = "Crunch Crunch, Yum!";
        }

        public string ChipsName { get; set; }
        public decimal ChipsPrice { get; set; }
        //public string Message { get; private set; }

    }

    // Properties



    //Methods


}
