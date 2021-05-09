using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public enum ProductCategory
    {
        Dairy = 1,
        Fruit = 2,
        Sweet = 3
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
