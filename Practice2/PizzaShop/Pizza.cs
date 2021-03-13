using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop
{
    public enum Size
    {
        Small, 
        Medium, 
        Large
    }
    public class Pizza
    {
        public string Name { get; set; }
        public Size Size { get; set; }
        public decimal Price { get; set; }
    }
}
