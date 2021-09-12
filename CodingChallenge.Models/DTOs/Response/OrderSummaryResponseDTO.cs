using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models.DTOs.Response
{
    public class OrderSummaryResponseDTO
    {
        public OrderSummaryResponseDTO()
        {
            this.Products = new List<ProductSummaryResponseDTO>();
        }
        public int ID { get; set; }

        public IList<ProductSummaryResponseDTO> Products { get; set; }

        public double Total { get; set; }
        public double SalesTaxes { get; set; }
    }
}
