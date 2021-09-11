using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Repositories.DBContexts
{
    public class LocalDBContext : DbContext
    {
        public DbSet<Models.Tax> Taxes { get; set; }
        public DbSet<Models.Department> Departments { get; set; }
        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.Product> Product { get; set; }
    }
}
