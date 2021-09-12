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
    public partial class TaxRepository : ITaxRepository, IDisposable
    {
        private DBContexts.LocalDBContext context;

        public TaxRepository(DBContexts.LocalDBContext context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            var entity = context.Taxes.Find(id);
            context.Taxes.Remove(entity);
        }

        public async Task<IEnumerable<Tax>> GetAll()
        {
            return await context.Taxes.ToListAsync();
        }

        public async Task<Tax> GetByID(int id)
        {
            return await context.Taxes.FirstOrDefaultAsync(d => d.ID == id);
        }

        public void Insert(Tax entity)
        {
            context.Taxes.Add(entity);
        }

        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }

        public void Update(Tax entity)
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

        public async Task<IEnumerable<Tax>> GetAllForImported()
        {
            return await context.Taxes.Where(t => t.ForImported).ToListAsync();
        }
    }
}
