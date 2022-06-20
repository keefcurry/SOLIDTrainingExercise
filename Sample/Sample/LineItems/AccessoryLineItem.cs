using System;
using System.Collections.Generic;
using System.Text;

namespace Sample
{
    public class AccessoryLineItem : LineItem
    {
        public override decimal AmountPerContainer => 1;
        public override decimal ContainersRequired => 1;
        public override decimal MaterialCost => Price * Quantity;
        protected override void UpdateEstimatedQuantityForNewContainersRequired(decimal containersRequired)
        {
            throw new NotImplementedException();
        }
    }
}
