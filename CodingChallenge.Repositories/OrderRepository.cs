using CodingChallenge.Models;
using CodingChallenge.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Repositories
{
    public partial class OrderRepository : IOrderRepository, IDisposable
    {
        private DBContexts.LocalDBContext context;

        public OrderRepository(DBContexts.LocalDBContext context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            var entity = context.Orders.Find(id);
            context.Orders.Remove(entity);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await context.Orders.Include(d => d.Products).ToListAsync();
        }

        public async Task<Order> GetByID(int id)
        {
            return await context.Orders.Include(d => d.Products).FirstOrDefaultAsync(d => d.ID == id);
        }

        public void Insert(Order entity)
        {
            context.Orders.Add(entity);
        }

        public async Task<int> Save()
        {
           return await context.SaveChangesAsync();
        }

        public void Update(Order entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
