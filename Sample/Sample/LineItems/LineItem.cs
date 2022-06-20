using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample
{

    public abstract class LineItem 
    {
        private const int VentChute = 65;
        private const int SlopedCeiling = 57;

        public decimal TaxAmount => MaterialCost * TaxRate;
        public int? WorkOrderId { get; internal set; }
        public virtual string Description { get; internal set; }
        public virtual decimal? Depth { get; set; }
        public virtual decimal? RValuePerInch { get; set; }
        public virtual decimal? RValue { get; set; }
        public virtual decimal Yield { get; private set; } = 0;
        public virtual decimal LaborRate { get; private set; } = 0;
        public virtual decimal Discount { get; private set; } = 0;
        public virtual decimal MarkUp { get; private set; } = 0;
        public virtual decimal TaxRate { get; set; } = .1M;
        public virtual bool Taxable { get; private set; } = true;
        public virtual bool SurchargeExempt { get; private set; } = false;

        //Maybe I could even extract these five properties into their own Estimate.cs and use it as an object here
        public int EstimateId { get; internal set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; internal set; } = 0;
        public bool DoNotShowOnEstimate { get; internal set; } = false;
        public bool DoNotShowOnWorkOrder { get; internal set; } = false;
        public string BaseDescription => $"{WorkArea?.Name} {MaterialRecord?.Material?.Name}";

        public LineItemStatusEnum Status { get; internal set; } = LineItemStatusEnum.Normal;
        public LineItemCategoryEnum LineItemCategory { get; internal set; }
        public MaterialRecord MaterialRecord { get; internal set; }
        public WorkArea WorkArea { get; internal set; }
        public List<ReplacedLineItem> ReplacedLineItems { get; internal set; }

        public virtual string Name { get { return BaseDescription; } }
        public virtual decimal AmountPerContainer { get; set; } = 0;
        public virtual decimal ContainersRequired { get; set; } = 0;
        public virtual string ContainerName { get; set; } = "";
        public virtual decimal MaterialCost { get { throw new InvalidOperationException("Invalid Material Type"); } set { } }
        public virtual decimal Profit { get
            {
                return Total - (TotalLabor + MaterialCost) - (MaterialCost * TaxRate) - (TotalLabor * Settings.Instance.TotalLaborSurchargePercent);
            }
            set { }
        }
        public virtual decimal Total { get
            {        
                decimal markup = MarkUp != 0 ? MarkUp : 1;
                decimal adjustedLaborRate = (LaborRate * Quantity) / markup;
                decimal adjustedMaterialCost = MaterialCost / markup;
                decimal tax = MaterialCost * TaxRate;
                decimal laborRateSurcharge = (LaborRate * Quantity * Settings.Instance.TotalLaborSurchargePercent);
                return Helpers.RoundUp(adjustedMaterialCost + adjustedLaborRate + tax + laborRateSurcharge, 2);
            }
            set { }
        }

        public decimal UnitPrice => Total / (Quantity == 0 ? 1 : Quantity);
        public decimal TotalLabor => LaborRate * Quantity;

        public bool IsOptionItem =>
            new Enum[] {
                LineItemStatusEnum.OptionItem,
                LineItemStatusEnum.RejectedOptionItem,
                LineItemStatusEnum.AcceptedOptionItem
            }.Contains(Status);

        public bool IsVentChute => MaterialRecord?.Material?.Id == VentChute;
        public bool IsSlopedCeilingLineItem => WorkArea.Id == SlopedCeiling && !IsVentChute;
        public bool AffectsSlopedCeilingLineItems => IsSlopedCeilingLineItem || (ReplacedLineItems?.Where(l => l.LineItem?.IsSlopedCeilingLineItem ?? false).Any() ?? false);

        public void UpdateEstimatedFields(decimal containersRequired, decimal taxRate)
        {
            UpdateEstimatedQuantityForNewContainersRequired(containersRequired);
            TaxRate = taxRate;
        }

        protected abstract void UpdateEstimatedQuantityForNewContainersRequired(decimal containersRequired);

        internal void MarkReplaced()
        {
            if (Status == LineItemStatusEnum.Normal && MaterialRecord.Material.Id != VentChute)
            {
                Status = LineItemStatusEnum.Replaced;
            }
        }

        internal void MarkNotReplaced()
        {
            if (Status == LineItemStatusEnum.Replaced)
            {
                Status = LineItemStatusEnum.Normal;
            }
        }

        public bool IsMatch(LineItem lineItem)
        {
            return lineItem.Quantity == Quantity
                   && lineItem.MaterialRecord.MaterialRecordId == MaterialRecord.MaterialRecordId
                   && lineItem.WorkArea.Id == WorkArea.Id
                   && lineItem.Depth == Depth
                   && lineItem.Status == Status
                   && lineItem.Taxable == Taxable
                   && lineItem.RValue == RValue
                   && lineItem.RValuePerInch == RValuePerInch
                   && lineItem.Yield == Yield;
        }     
    }
}
