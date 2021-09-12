using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models.DTOs.Response
{
    public partial class ProductSummaryResponseDTO
    {
        public string Description { get; set; }
        public int Count { get; set; }
        public double PriceTotal { get; set; }
        public double UnitPrice { get; set; }
        /// <summary>
        /// Returns Product Department Name
        /// </summary>
        public string DepartmentName { get; set; }
        public bool Imported { get; set; }
    }
}
