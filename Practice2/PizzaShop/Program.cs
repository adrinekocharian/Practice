using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza1 = new Pizza() { Name = "A", Price = 10, Size = Size.Small };
            Pizza pizza2 = new Pizza() { Name = "A", Price = 150, Size = Size.Large };
            Pizza pizza3 = new Pizza() { Name = "B", Price = 20, Size = Size.Medium };

            PizzaOrder order = new PizzaOrder();
            order.Pizzas.Add(pizza1);
            order.Pizzas.Add(pizza2);
            order.Pizzas.Add(pizza3);

            PizzaOrderingSystem system = new PizzaOrderingSystem();
            var discount = system.CalculateDiscount(order);

            Console.WriteLine($"Order total price is {order.Price}");
            Console.WriteLine($"Discount is {discount}.");
            Console.WriteLine($"Final price is {order.Price - discount}");

            Console.ReadLine();
        }
    }
}
