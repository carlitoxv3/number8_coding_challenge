using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodingChallenge.Models
{
    /// <summary>
    /// Defines the order entity, that contains products
    /// </summary>
    public partial class Order : BaseClass
    {
        public Order() : base()
        {
        }

        public IList<Product> Products { get; set; }
    }
}
