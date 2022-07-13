using System;
using System.Collections.Generic;
using System.Text;

namespace Sample
{
    public class FiberglassLineItem : LineItem
    {
        FiberglassLineItem()
        {
            ContainerName = "Bags";
        }
        public override decimal LaborRate => .06M;
        public override decimal MarkUp => .57M;
        public override decimal AmountPerContainer => MaterialRecord.AmountPerContainer.Value;
        public override decimal ContainersRequired => Quantity / AmountPerContainer;
        public override decimal MaterialCost => Price * Quantity;
        protected override void UpdateEstimatedQuantityForNewContainersRequired(decimal containersRequired)
        {
            throw new NotImplementedException();
        }
    }
}
