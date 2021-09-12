using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CodingChallenge.Models.DTOs.Response
{
    public partial class ProductSummaryResponseDTO
    {
        public string Description { get; set; }
        public int Count { get; set; }
        public double PriceTotal { get; set; }
        public double UnitPrice { get; set; }
        [JsonIgnore]
        public double TaxTotal { get; set; }
        /// <summary>
        /// Returns Product Department Name
        /// </summary>
        public string DepartmentName { get; set; }
        public bool Imported { get; set; }
    }
}
