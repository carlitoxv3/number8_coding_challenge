using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Repositories.DBContexts
{
    /// <summary>
    /// Defines local Context with entities
    /// </summary>
    public class LocalDBContext : DbContext
    {
        public DbSet<Models.Tax> Taxes { get; set; }
        public DbSet<Models.Department> Departments { get; set; }
        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.Product> Product { get; set; }

        public LocalDBContext(DbContextOptions<LocalDBContext> options)
              : base(options)
        {
        }
        public LocalDBContext()
                : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Defines relationships
            builder.Entity<Models.Product>(entity => entity.HasOne(m => m.Department));
            
            builder.Entity<Models.Order>(entity => entity.HasMany(m => m.Products));
        }

    }
}
