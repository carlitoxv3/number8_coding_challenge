using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Services.Extensions
{
    public static class ExtensionsMethods
    {
        /// <summary>
        /// Returns the number with the round using step
        /// </summary>
        /// <param name="value">Number to round</param>
        /// <param name="roundTo">Step to round</param>
        /// <returns></returns>
        public static double RoundCentimalTo(this double value, double roundTo)
        {
            return Math.Round(Math.Ceiling(value / roundTo) * roundTo, 2);
        }
    }
}
