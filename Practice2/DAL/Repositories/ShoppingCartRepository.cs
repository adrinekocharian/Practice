using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository, IDisposable
    {
        private ShopDbContext dbContext;
        public ShoppingCartRepository(string connectionString)
        {
            dbContext = new ShopDbContext(connectionString);
        }
        public ShoppingCart Create(ShoppingCart entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ShoppingCart entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            dbContext?.Dispose();
            dbContext = null;
        }

        public void LastWeekOrders()
        {
            throw new NotImplementedException();
        }

        public void PlaceOrder(ShoppingCart order)
        {
            dbContext.ShoppingCarts.Add(order);
            dbContext.SaveChanges();
        }

        public void PlaceOrder()
        {
            throw new NotImplementedException();
        }

        public IList<ShoppingCart> ReadAll()
        {
            throw new NotImplementedException();
        }

        public ShoppingCart ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart Update(ShoppingCart entity)
        {
            throw new NotImplementedException();
        }
    }
}
