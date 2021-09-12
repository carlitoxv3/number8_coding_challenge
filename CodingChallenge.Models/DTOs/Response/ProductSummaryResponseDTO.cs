using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CodingChallenge.Models.DTOs.Response
{
    /// <summary>
    /// Defines the response DTO for Product
    /// </summary>
    public partial class ProductSummaryResponseDTO
    {
        public string Description { get; set; }
        /// <summary>
        /// Count of unit that contains the item
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Total price of items with taxes
        /// </summary>
        public double PriceTotal { get; set; }
        /// <summary>
        /// Unit price of item with taxes
        /// </summary>
        public double UnitPrice { get; set; }
        [JsonIgnore]
        public double TaxTotal { get; set; }
        /// <summary>
        /// Returns Product Department Name
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// Defines if is imported
        /// </summary>
        public bool Imported { get; set; }
    }
}
