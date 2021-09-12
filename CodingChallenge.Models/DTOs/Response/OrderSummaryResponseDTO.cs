using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Models.DTOs.Response
{
    /// <summary>
    /// Defines the response DTO for Order
    /// </summary>
    public partial class OrderSummaryResponseDTO
    {
        public OrderSummaryResponseDTO()
        {
            this.Products = new List<ProductSummaryResponseDTO>();
        }
        public int ID { get; set; }
        /// <summary>
        /// List of products in order
        /// </summary>
        public List<ProductSummaryResponseDTO> Products { get; set; }

        /// <summary>
        /// Returns the total amount based in list of products (calculated field), Rouded in 2 decimals
        /// </summary>
        public double Total { get { return Products != null && Products.Any() ? Math.Round(Products.Sum(p => p.PriceTotal), 2) : 0; } }
        /// <summary>
        /// Returns the total of taxes amount based in list of products (calculated field), Rouded in 2 decimals
        /// </summary>
        public double SalesTaxes { get { return Products != null && Products.Any() ? Math.Round(Products.Sum(p => p.TaxTotal), 2) : 0; } }
    }
}
