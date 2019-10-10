using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Slots
    {
        public Slots(string slotID)
        {
            Amount = 5;
            SlotID = slotID;
        }

        public int Amount { get; set; }
        public string SlotID { get; private set; }






    }




}
