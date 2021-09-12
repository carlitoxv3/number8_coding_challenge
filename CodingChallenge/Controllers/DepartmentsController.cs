using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentsController : Controller
    {
        private Services.Interfaces.IDepartmentService _departmentService;
        public DepartmentsController(Services.Interfaces.IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public async Task<IEnumerable<Models.Department>> Get()
        {
            return await this._departmentService.GetAll();
        }
    }
}
