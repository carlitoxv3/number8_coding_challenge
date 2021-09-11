using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Repositories.DBContexts.Seeds
{
    public class SeedInitializer
    {
        /// <summary>
        /// Set initial data
        /// </summary>
        /// <param name="context">Local DBContext</param>
        /// <returns></returns>
        public static async Task Initialize(LocalDBContext context)
        {
            //Check if database exists
            context.Database.EnsureCreated();

            ///Check if doesn't have taxes inserted
            if (!context.Taxes.Any())
            {
                context.Taxes.Add(new Models.Tax() { ID = 1, Value = 10 });
                context.Taxes.Add(new Models.Tax() { ID = 2, Value = 5 });
                await context.SaveChangesAsync();
            }

            ///Check if doesn't have departmens inserted
            if (!context.Departments.Any())
            {
                context.Departments.Add(new Models.Department() { ID = 1, Name = "Books" });
                context.Departments.Add(new Models.Department() { ID = 2, Name = "Food" });
                context.Departments.Add(new Models.Department() { ID = 3, Name = "Medicals" });
                context.Departments.Add(new Models.Department() { ID = 4, Name = "Imported", TaxID = 2 });
                context.Departments.Add(new Models.Department() { ID = 4, Name = "Music", TaxID = 1 });
                context.Departments.Add(new Models.Department() { ID = 4, Name = "Marchandising", TaxID = 1 });
                context.Departments.Add(new Models.Department() { ID = 4, Name = "Toys", TaxID = 1 });
                context.Departments.Add(new Models.Department() { ID = 4, Name = "Other", TaxID = 1 });
                await context.SaveChangesAsync();
            }
        }
    }
}
