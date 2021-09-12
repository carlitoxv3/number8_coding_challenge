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

        public bool ForImported { get; set; } = false;

        public double Value { get; set; }

    }
}
