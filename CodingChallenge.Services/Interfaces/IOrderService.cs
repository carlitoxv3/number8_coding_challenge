using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Services.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Receive an order with items and process them to get the current totals
        /// </summary>
        /// <param name="orderRequestDTO">Order to be proccess</param>
        /// <returns>Return the totals and taxes that was applied</returns>
        Task<Models.DTOs.Response.OrderSummaryResponseDTO> Calculate(Models.DTOs.Request.OrderRequestDTO orderRequestDTO);
    }
}
