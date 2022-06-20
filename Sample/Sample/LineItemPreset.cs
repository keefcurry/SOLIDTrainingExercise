using System;
using System.Collections.Generic;
using System.Text;

namespace Sample
{
    public class LineItemPreset
    {
        public LineItemPreset(string description,
            decimal? depth,
            decimal? rValuePerInch,
            int? rValue,
            decimal yield,
            decimal laborRate,
            decimal discount,
            decimal markUp,
            decimal? taxRate,
            bool taxable,
            bool surchargeExempt,
            Material material)
        {
            Description = description;
            Depth = depth;
            RValuePerInch = rValuePerInch;
            RValue = rValue;
            Yield = yield;
            LaborRate = laborRate;
            Discount = discount;
            MarkUp = markUp;
            TaxRate = taxRate ?? .1M;
            Taxable = taxable;
            SurchargeExempt = surchargeExempt;
        }

        public LineItemPreset(Material material)
        {
        }

        //private constructor for EF
        private LineItemPreset()
        {
        }

        public string Description { get; internal set; }
        public decimal? Depth { get; set; }
        public decimal? RValuePerInch { get; set; }
        public decimal? RValue { get; set; }
        public decimal Yield { get; private set; } = 0;
        public decimal LaborRate { get; private set; } = 0;
        public decimal Discount { get; private set; } = 0;
        public decimal MarkUp { get; private set; } = 0;
        public decimal TaxRate { get; set; } = .1M;
        public bool Taxable { get; private set; } = true;
        public bool SurchargeExempt { get; private set; } = false;
    }
}
