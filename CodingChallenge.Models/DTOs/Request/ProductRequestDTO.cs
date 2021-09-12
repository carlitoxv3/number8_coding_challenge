using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models.DTOs.Request
{
    public class ProductRequestDTO
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsImported { get; set; }
        /// <summary>
        /// Returns Product Department ID
        /// </summary>
        public int DepartmentID { get; set; }
    }
}
