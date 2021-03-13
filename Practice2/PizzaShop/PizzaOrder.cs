using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaShop
{
    public class PizzaOrder
    {
        public decimal Price
        {
            get
            {
                //decimal totalPrice = 0;
                //foreach (Pizza pizza in this.Pizzas)
                //{
                //    totalPrice += pizza.Price;
                //}
                //return totalPrice;

                return this.Pizzas.Sum(p => p.Price);
            }
        }
        public List<Pizza> Pizzas { get; set; }
        public PizzaOrder()
        {
            this.Pizzas = new List<Pizza>();
        }
    }
}
