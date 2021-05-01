using DAL;
using DAL.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            //AddProducts();
            //ReadProducts();
            PlaceOrder();
            Console.ReadLine();
        }

        static void PlaceOrder()
        {
            var products = ReadProducts();
         
            var orange = new Product()
            {
                Name = "orange",
                Price = 800,
                Quantity = 1000,
                Category = ProductCategory.Fruit
            };
            var Cheese = new Product()
            {
                Name = "cheese",
                Price = 1600,
                Quantity = 50,
                Category = ProductCategory.Dairy
            };
            using (ShopDbContext dbContext = new ShopDbContext())
            {
                int prod_id = products.First(x => x.Price > 500).Id;
                int itemsCount = 3;
                if (products.Where(x => x.Id == prod_id).Count() > itemsCount)
                {
                    var item3 = new CartItem()
                    {
                        ProductId = prod_id,
                        Count = itemsCount
                    };
                }

                var item1 = new CartItem()
                {
                    ProductId = prod_id,
                    Count = 2
                };
                var item2 = new CartItem()
                {
                    ProductId = 6,                    
                    Count = 1                
                };
                List<CartItem> cartItems = new List<CartItem>() { item1, item2 };

                var shoppingCart = new ShoppingCart()
                {
                    CreatedOn = DateTime.Now,
                    CartItems = cartItems,
                    ItemsCount = cartItems.Sum(cartItems => cartItems.Count),
                    //TotalPrice = cartItems.Sum(p => p.Product.Price * p.Count)
                };

                dbContext.shoppingCarts.Add(shoppingCart);
                //dbContext.Products.First(x => x.Id == 2).Name = "x";
                Console.Write(dbContext.Entry(shoppingCart).State);

                dbContext.SaveChanges();
            }
        }

        static IEnumerable<Product> ReadProducts()
        {
            List<Product> products = new List<Product>();
            using (ShopDbContext dbContext = new ShopDbContext())
            {
                products = dbContext.Products.ToList();
                foreach (var item in products)
                {
                    Console.WriteLine(item);
                    Console.Write(dbContext.Entry(item).State);
                }

                var categoies = dbContext.Categories.ToList();
            }
            return products;
        }
        static void AddProducts()
        {
            var orange = new Product()
            {
                Name = "orange",
                Price = 800,
                Quantity = 1000,
                Category = ProductCategory.Fruit
            };
            var Cheese = new Product()
            {
                Name = "cheese",
                Price = 1600,
                Quantity = 50,
                Category = ProductCategory.Dairy
            };
            var candy = new Product()
            {
                Name = "kitkat",
                Price = 250,
                Quantity = 2000,
                Category = ProductCategory.Sweet
            };
            var apple = new Product()
            {
                Name = "apple",
                Price = 400,
                Quantity = 700,
                Category = ProductCategory.Fruit
            };
            using (ShopDbContext dbContext = new ShopDbContext())
            {
                dbContext.Products.Add(orange);
                dbContext.Products.Add(candy);
                dbContext.Products.Add(apple);
                dbContext.Products.Add(Cheese);

                dbContext.SaveChanges(); 
            }
        }
    }
}
