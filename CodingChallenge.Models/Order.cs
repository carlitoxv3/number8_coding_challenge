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
            Products = new List<Product>();
        }

        public IEnumerable<Product> Products { get; set; }
    }
}
