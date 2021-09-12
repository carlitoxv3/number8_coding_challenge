using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class DepartmentsController : Controller
    {
        private Services.Interfaces.IDepartmentService _departmentService;
        public DepartmentsController(Services.Interfaces.IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        /// <summary>
        /// Return the list of existents departments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Models.DTOs.Response.DepartmentResponseDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await this._departmentService.GetAll());
            }
            catch (Exception ex)
            {
                // TODO: log error stack tracke
                return BadRequest(ex.Message);
            }
        }
    }
}
