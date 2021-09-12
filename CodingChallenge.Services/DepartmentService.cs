using CodingChallenge.Models;
using CodingChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Department>> GetAll()
        {
            try
            {
                _departmentRepository = new Repositories.DepartmentRepository(this._localDBContext);
                return await _departmentRepository.GetAll();
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
