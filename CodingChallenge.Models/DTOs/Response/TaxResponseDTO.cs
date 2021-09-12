using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models.DTOs.Response
{
    public class TaxResponseDTO
    {
        public int ID { get; set; }
        public bool ForImported { get; set; } = false;
        public double Value { get; set; }
    }
}
