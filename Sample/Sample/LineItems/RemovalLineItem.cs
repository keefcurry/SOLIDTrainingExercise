using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.LineItems
{
    public class RemovalLineItem : LineItem
    {
        public override decimal MaterialCost => 0;
        public override decimal Profit => Total - TotalLabor - -(TotalLabor * Settings.Instance.TotalLaborSurchargePercent);
        protected override void UpdateEstimatedQuantityForNewContainersRequired(decimal containersRequired)
        {
            throw new NotImplementedException();
        }
    }
}
