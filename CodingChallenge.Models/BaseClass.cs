using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodingChallenge.Models
{
    /// <summary>
    /// Define base class, that contains ID, CreatedAt and UpdatedAt properties
    /// </summary>
    public class BaseClass 
    {
        public BaseClass()
        {
            this.CreatedAt = DateTime.UtcNow;
        }

        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Get/Sets created date and time
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Get/Sets updated date and time
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
