using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models
{
    /// <summary>
    /// Defines the tax entity
    /// </summary>
    public partial class Tax : BaseClass
    {
        public Tax() : base()
        {
        }

        public float Value { get; set; }

    }
}
