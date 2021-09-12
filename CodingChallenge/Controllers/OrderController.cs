using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private Services.Interfaces.IOrderService _orderService;
        public OrderController(Services.Interfaces.IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("[action]")]
        public async Task<ActionResult> SaveAndCalculate([FromBody][Required] Models.DTOs.Request.OrderRequestDTO orderRequestDTO)
        {

            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                

                return Ok(await this._orderService.SaveAndCalculate(orderRequestDTO));
            }
            catch (Exception ex)
            {
                // TODO: log error stack tracke
                return BadRequest(ex.Message);
            }
        }
    }
}
