using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Materials
{
    public class FoamLineItem : LineItem
    {
        FoamLineItem()
        {
            ContainerName = "Sets";
        }
        public override decimal LaborRate => .23M;
        public override decimal MarkUp => .6M;
        public override string Name => $"R{Math.Round(RValue ?? 0, 0)} {MaterialRecord?.Material?.Name} {Math.Round(Depth ?? 0, 2)}in.";
        public override decimal AmountPerContainer => (Quantity * Depth.Value) / Yield;
        public override decimal ContainersRequired => AmountPerContainer;
        public override decimal MaterialCost => Price * AmountPerContainer;

        protected override void UpdateEstimatedQuantityForNewContainersRequired(decimal containersRequired)
        {
            throw new NotImplementedException();
        }
    }
}
