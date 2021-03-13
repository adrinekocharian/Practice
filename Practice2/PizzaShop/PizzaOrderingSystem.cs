using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaShop
{
    public class PizzaOrderingSystem
    {
        public DiscountPolicy[] polices;
        public DiscountPolicy discountPolicy;
        public PizzaOrderingSystem()
        {
            discountPolicy += PizzaDiscounts.BuyMoreThanOneGetOneFree;
            discountPolicy += PizzaDiscounts.TenPercentOffForMoreThanFiftyDollars;

            polices = new DiscountPolicy[] { 
                PizzaDiscounts.BuyMoreThanOneGetOneFree, 
                PizzaDiscounts.TenPercentOffForMoreThanFiftyDollars
                //PizzaDiscounts.FivePercentOffForAllPizzas
            };
        }
        public decimal CalculateDiscount(PizzaOrder order)
        {
            decimal discount = 0m;
            discountPolicy.Invoke(order, ref discount);
            return discount;
            
            //return this.polices.Max(policy => policy.Invoke(order));
        }
    }
}
