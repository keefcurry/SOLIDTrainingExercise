using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.LineItems
{
    public class NotApplicableLineItem : LineItem
    {
        protected override void UpdateEstimatedQuantityForNewContainersRequired(decimal containersRequired)
        {
            throw new NotImplementedException();
        }
    }
}
