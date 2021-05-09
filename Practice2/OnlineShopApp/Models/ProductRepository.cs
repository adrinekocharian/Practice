using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopDbContext dbContext;
        public ProductRepository(OnlineShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return this.dbContext.Products;
        }

        public Product GetProductById(int id)
        {
            return this.dbContext.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
