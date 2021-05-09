using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly OnlineShopDbContext dbContext;

        public CategoryRepository(OnlineShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Category> Categories => this.dbContext.Categories;
    }
}
