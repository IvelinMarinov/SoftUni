using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AndreyAndBilliard
{
    public class Customer
    {
        public string Name { get; set; }

        public Dictionary<string, int> Order { get; set; }

        public double Bill { get; set; }        
    }
}
