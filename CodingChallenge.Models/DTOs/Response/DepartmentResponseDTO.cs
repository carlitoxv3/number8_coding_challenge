using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models.DTOs.Response
{
    public class DepartmentResponseDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Returns Department Tax associated
        /// </summary>
        public virtual IList<TaxResponseDTO> Taxes { get; set; }
    }
}
