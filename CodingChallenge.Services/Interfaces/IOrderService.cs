using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Services.Interfaces
{
    public interface IOrderService
    {

        Task<Models.DTOs.Response.OrderSummaryResponseDTO> SaveAndCalculate(Models.DTOs.Request.OrderRequestDTO orderRequestDTO);
    }
}
