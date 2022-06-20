using System;
using System.Collections.Generic;
using System.Text;

namespace Sample
{
    public class MaterialRecord
    {
        private MaterialRecord()
        {
        }

        public int? MaterialRecordId { get; internal set; }
        public decimal Price { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public int MaterialId { get; private set; }
        public bool Priority { get; private set; } = false;
        public decimal? AmountPerContainer { get; private set; }
        public string SKU { get; private set; }
        public string Manufacturer { get; private set; }
        public decimal? RValue { get; private set; }
        public LineItemPreset LineItemPreset { get; private set; }
        public Material Material { get; private set; }

    }
}
