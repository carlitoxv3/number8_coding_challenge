using CodingChallenge.Models;
using CodingChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Services
{
    public partial class DepartmentService : IDepartmentService
    {
        private Repositories.Interfaces.IDepartmentRepository _departmentRepository;
        private Repositories.DBContexts.LocalDBContext _localDBContext;
        public DepartmentService(
            Repositories.DBContexts.LocalDBContext localDBContext
            )
        {
            _localDBContext = localDBContext;
        }

        public async Task<IEnumerable<Models.DTOs.Response.DepartmentResponseDTO>> GetAll()
        {
            try
            {
                IEnumerable<Models.DTOs.Response.DepartmentResponseDTO> responseDTOs = new List<Models.DTOs.Response.DepartmentResponseDTO>();
                _departmentRepository = new Repositories.DepartmentRepository(this._localDBContext);
                var departments = await _departmentRepository.GetAll();

                if (departments != null && departments.Any())
                {
                    responseDTOs = departments.Select(d => new Models.DTOs.Response.DepartmentResponseDTO()
                    {
                        ID = d.ID,
                        Name = d.Name,
                        Taxes = d.Taxes.Select(t => new Models.DTOs.Response.TaxResponseDTO()
                        {
                            ID = t.ID,
                            ForImported = t.ForImported,
                            Value = t.Value
                        }).ToList()
                    });
                }
                return responseDTOs;
            }
            catch (Exception ex)
            {
                // TODO: Make log
                throw ex;
            }
        }

        public async Task<Department> GetByID(int id)
        {
            try
            {
                _departmentRepository = new Repositories.DepartmentRepository(this._localDBContext);
                return await _departmentRepository.GetByID(id);
            }
            catch (Exception ex)
            {
                // TODO: Make log
                throw ex;
            }
        }
    }
}
