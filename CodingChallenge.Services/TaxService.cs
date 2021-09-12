using CodingChallenge.Models;
using CodingChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Services
{
    public partial class TaxService : ITaxService
    {
        private Repositories.Interfaces.ITaxRepository _taxRepository;
        private Repositories.DBContexts.LocalDBContext _localDBContext;
        public TaxService(
            Repositories.DBContexts.LocalDBContext localDBContext
            )
        {
            _localDBContext = localDBContext;
        }

        public async Task<IEnumerable<Tax>> GetAll()
        {
            try
            {
                _taxRepository = new Repositories.TaxRepository(this._localDBContext);
                return await _taxRepository.GetAll();
            }
            catch (Exception ex)
            {
                // TODO: Make log
                throw ex;
            }
        }

        public async Task<IEnumerable<Tax>> GetAllForImported()
        {
            try
            {
                _taxRepository = new Repositories.TaxRepository(this._localDBContext);
                return await _taxRepository.GetAllForImported();
            }
            catch (Exception ex)
            {
                // TODO: Make log
                throw ex;
            }
        }

        public async Task<Tax> GetByID(int id)
        {
            try
            {
                _taxRepository = new Repositories.TaxRepository(this._localDBContext);
                return await _taxRepository.GetByID(id);
            }
            catch (Exception ex)
            {
                // TODO: Make log
                throw ex;
            }
        }
    }
}
