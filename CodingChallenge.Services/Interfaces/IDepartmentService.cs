using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Services.Interfaces
{
    public interface IDepartmentService
    {

        Task<IEnumerable<Models.DTOs.Response.DepartmentResponseDTO>> GetAll();
        Task<Models.Department> GetByID(int id);
    }
}
