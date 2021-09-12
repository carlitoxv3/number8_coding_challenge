using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private Services.Interfaces.IOrderService _orderService;
        public OrderController(Services.Interfaces.IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Receives an order item with products, check the existence of deparments
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Calculate
        ///     {
        ///       "products": [
        ///         {
        ///     	  "Code":"perfume",
        ///           "description": "bootle of perfume",
        ///           "price": 47.50,
        ///           "isImported": true,
        ///           "departmentID": 4
        ///         },
        ///     	{
        ///     		 "Code":"chbar",
        ///           "description": "Chocolate bar",
        ///           "price": 10,
        ///           "isImported": true,
        ///           "departmentID": 2
        ///         }
        ///       ]
        ///     }
        ///
        /// </remarks>
        /// <param name="orderRequestDTO">Order to be process</param>
        /// <returns>Returns an order with totals and taxes applied</returns>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(Models.DTOs.Response.OrderSummaryResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Calculate([FromBody][Required] Models.DTOs.Request.OrderRequestDTO orderRequestDTO)
        {

            try
            {
                // Check if the DTO is correct
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                // Execute the service method to calculate
                return Ok(await this._orderService.Calculate(orderRequestDTO));
            }
            catch (Exception ex)
            {
                // TODO: log error stack tracke
                return BadRequest(ex.Message);
            }
        }
    }
}
