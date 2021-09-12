using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Services.Interfaces
{
    public interface ITaxService
    {

        Task<IEnumerable<Models.Tax>> GetAll();
        Task<Models.Tax> GetByID(int id);
        Task<IEnumerable<Tax>> GetAllForImported();
    }
}
