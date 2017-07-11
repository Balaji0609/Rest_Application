using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wesiteApp
{
    public class Computer
    {
        public string PartName { get; set; }
        public string price { get; set; }
        public Computer()
        {
        }
        public Computer(string PartName, string price)
        {
            this.PartName = PartName;
            this.price = price;
        }
    }
}