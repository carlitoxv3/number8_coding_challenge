using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models.DTOs.Request
{
    public class OrderRequestDTO
    {
        public OrderRequestDTO() : base()
        {
        }

        public IList<ProductRequestDTO> Products { get; set; }
    }
}
