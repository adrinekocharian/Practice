using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaShop
{
    public delegate void DiscountPolicy(PizzaOrder order, ref decimal discount);
    public static class PizzaDiscounts
    {
        public static void BuyMoreThanOneGetOneFree(PizzaOrder order, ref decimal discount)
        {
            var pizzas = order.Pizzas;
            if (pizzas.Count >= 2)
            {
                //return pizzas.Min(MinPricedPizza);
                var currDis = pizzas.Min(pizza => pizza.Price);
                discount = currDis > discount ? currDis : discount; // discount = DiscountApplied(discount, currDis);
            }
        }
        public static void TenPercentOffForMoreThanFiftyDollars(PizzaOrder order, ref decimal discount)
        {
            //decimal discount = 0;
            //decimal totalPrice = 0;
            //foreach (Pizza pizza in order.Pizzas)
            //{
            //    totalPrice += pizza.Price;
            //}

            //if (totalPrice >= 50)
            //{
            //    discount = totalPrice * 0.1m;
            //}
            //return discount;

            var price = order.Price;
            decimal currDis = price >= 50 ? price * 0.1m : 0m;
            discount = DiscountApplied(discount, currDis);
        }

        public static decimal FivePercentOffForAllPizzas(PizzaOrder order, ref decimal discount)
        {
            return order.Price * 0.05m;
        }

        #region Helpers
        private static decimal MinPricedPizza(Pizza pizza)
        {
            return pizza.Price;
        }

        private static decimal DiscountApplied(decimal discount, decimal currDis)
        {
            return discount = currDis > discount ? currDis : discount;
        }
        #endregion
    }
}
