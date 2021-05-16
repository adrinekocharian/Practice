using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private ShopDbContext dbContext;
        public ProductRepository(string connectionString)
        {
            dbContext = new ShopDbContext(connectionString);
        }

        public Product Create(Product entity)
        {
            dbContext.Products.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            dbContext?.Dispose();
            dbContext = null;
        }

        public IList<Product> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Product ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Product> GetAllProducts()
        {
            return dbContext.Products.ToList();
        }
    }
}
