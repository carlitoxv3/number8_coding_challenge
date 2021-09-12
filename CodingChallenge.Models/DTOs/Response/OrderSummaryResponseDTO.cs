using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<ProductSummaryResponseDTO> Products { get; set; }

        public double Total { get { return Products != null && Products.Any() ? Products.Sum(p => p.PriceTotal) : 0; } }
        public double SalesTaxes { get { return Products != null && Products.Any() ? Products.Sum(p => Math.Round(p.TaxTotal, 2)) : 0; } }
    }
}
