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
    public partial class DepartmentRepository : IDepartmentRepository, IDisposable
    {
        private DBContexts.LocalDBContext context;

        public DepartmentRepository(DBContexts.LocalDBContext context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            var entity = context.Departments.Find(id);
            context.Departments.Remove(entity);
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await context.Departments.Include(d => d.Tax).ToListAsync();
        }

        public async Task<Department> GetByID(int id)
        {
            return await context.Departments.Include(d => d.Tax).FirstOrDefaultAsync(d => d.ID == id);
        }

        public void Insert(Department entity)
        {
            context.Departments.Add(entity);
        }

        public async Task<int> Save()
        {
           return await context.SaveChangesAsync();
        }

        public void Update(Department entity)
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
