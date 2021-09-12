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

            var tax1 = new Models.Tax() { ID = 1, Value = 10 };
            var tax2 = new Models.Tax() { ID = 2, Value = 5, ForImported = true };

            ///Check if doesn't have taxes inserted
            if (!context.Taxes.Any())
            {
                context.Taxes.Add(tax1);
                context.Taxes.Add(tax2);
                await context.SaveChangesAsync();
            }

            ///Check if doesn't have departmens inserted
            if (!context.Departments.Any())
            {
                context.Departments.Add(new Models.Department() { ID = 1, Name = "Books" });
                context.Departments.Add(new Models.Department() { ID = 2, Name = "Food" });
                context.Departments.Add(new Models.Department() { ID = 3, Name = "Medicals" });
                context.Departments.Add(new Models.Department() { ID = 4, Name = "Other", Taxes = new List<Models.Tax>() { tax1 } });
                await context.SaveChangesAsync();
            }
        }
    }
}
