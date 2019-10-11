using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Gum : Item
    {
        public Gum (string gumName, decimal gumPrice) : base(gumName, gumPrice)
        {
            GumName = gumName;
            GumPrice = gumPrice;//Test Price hard coded. Will replace with StreamReader eventually
            //Message = "Chew Chew, Yum!";
            base.Message = "Chew Chew, Yum!";

        }

        public string GumName { get; set; }
        public decimal GumPrice { get; set; }
        //public string Message { get; private set; }
    }

    // Properties



    //Methods


}
