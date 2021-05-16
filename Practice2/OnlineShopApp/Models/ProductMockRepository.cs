using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class ProductMockRepository : IProductRepository
    {
        public void AddNewProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return new List<Product>
            {
                new Product(){ Name = "Yogurt", Price = 100, Quantity = 5, Category = ProductCategory.Dairy },
                new Product(){ Name = "Apple", Price = 300, Quantity = 35, Category = ProductCategory.Fruit },
            };
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
