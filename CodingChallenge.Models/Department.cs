using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodingChallenge.Models
{
    /// <summary>
    /// Defines department entity
    /// </summary>
    public partial class Department : BaseClass
    {
        public Department() : base()
        {
        }
        public string Name { get; set; }

        /// <summary>
        /// Returns Department Tax associated
        /// </summary>
        public virtual IList<Tax> Taxes { get; set; }
    }
}
