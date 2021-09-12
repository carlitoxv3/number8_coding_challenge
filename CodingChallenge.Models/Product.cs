using System;
using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models
{
    /// <summary>
    /// Defines the product entity
    /// </summary>
    public partial class Product : BaseClass
    {
        public Product() : base()
        {
        }
        public string Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Imported { get; set; } = false;
        /// <summary>
        /// Returns Product Department ID
        /// </summary>
        public int DepartmentID { get; set; }
        /// <summary>
        /// Returns Product Department (Food,Book,Medical,Imported, etc)
        /// </summary>
        public virtual Department Department { get; set; }
    }
}
