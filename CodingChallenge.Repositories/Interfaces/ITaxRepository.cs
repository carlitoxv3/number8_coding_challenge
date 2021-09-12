using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Repositories.Interfaces
{
    public interface ITaxRepository : IBaseRepository<Models.Tax>, IDisposable
    {
        Task<IEnumerable<Tax>> GetAllForImported();
    }
}
