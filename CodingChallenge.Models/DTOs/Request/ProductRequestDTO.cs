using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models.DTOs.Request
{
    public class ProductRequestDTO
    {
        [Required(ErrorMessage = "You must set a Code for the product")]
        public string Code { get; set; }
        public string Description { get; set; }
        [Required]

        public double Price { get; set; }
        public bool IsImported { get; set; }

        [Required]
        /// <summary>
        /// Returns Product Department ID
        /// </summary>
        public int DepartmentID { get; set; }
    }
}
