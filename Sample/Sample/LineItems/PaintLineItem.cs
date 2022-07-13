using System;
using System.Collections.Generic;
using System.Text;

namespace Sample
{
    public class PaintLineItem : LineItem
    {
        PaintLineItem()
        {
            ContainerName = "Gallons";
        }
        public override decimal AmountPerContainer => Yield;
        public override decimal ContainersRequired => Quantity / AmountPerContainer;
        public override decimal MaterialCost => Price * (Quantity / Yield);
        protected override void UpdateEstimatedQuantityForNewContainersRequired(decimal containersRequired)
        {
            throw new NotImplementedException();
        }
    }
}
