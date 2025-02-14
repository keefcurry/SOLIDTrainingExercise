﻿using System;

namespace Sample
{
    public class Helpers
    {
        public static decimal RoundUp(decimal input, int places)
        {
            decimal multiplier = Convert.ToDecimal(Math.Pow(10, Convert.ToDouble(places)));
            return Math.Ceiling(input * multiplier) / multiplier;
        }

        public static decimal GetRValue(decimal? rvalue)
        {
            return (int)rvalue == 0 ? 1 : (int)rvalue;
        }
    }
}
