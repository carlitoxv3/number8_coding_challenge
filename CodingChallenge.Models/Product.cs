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

        public string Name { get; set; }
        public double Price { get; set; }
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
