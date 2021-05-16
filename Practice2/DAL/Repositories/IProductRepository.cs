using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
        IEnumerable<Product> GetAllProducts();
    }
}
