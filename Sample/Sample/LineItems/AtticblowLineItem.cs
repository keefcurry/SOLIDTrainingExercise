using System;
using System.Collections.Generic;
using System.Text;

namespace Sample
{
    public class AtticblowLineItem : LineItem
    {
        AtticblowLineItem()
        {
            ContainerName = "Bags";
        }
        public override decimal LaborRate => .05M;
        public override decimal MarkUp => .0M;
        public override string Name => $"R{Math.Round(RValue ?? 0, 0)} { BaseDescription }";
        public override decimal AmountPerContainer => Settings.Instance.AtticBlowSqftBase/ Helpers.GetRValue(RValue ?? 0);
        public override decimal ContainersRequired => Quantity / AmountPerContainer;
        public override decimal MaterialCost => Price * ContainersRequired;
        protected override void UpdateEstimatedQuantityForNewContainersRequired(decimal containersRequired)
        {
            throw new NotImplementedException();
        }
    }
}
