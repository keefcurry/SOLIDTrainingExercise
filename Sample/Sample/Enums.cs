using System;
using System.Collections.Generic;
using System.Text;

namespace Sample
{
    public enum LineItemStatusEnum
    {
        Error = 0,
        Normal = 1,
        Replaced = 2,
        OptionItem = 3,
        AcceptedOptionItem = 4,
        RejectedOptionItem = 5
    }

    public enum LineItemCategoryEnum
    {
        Error = 0,
        Install = 1,
        Removal = 2,
        Fee = 3,
        SystemManaged = 4
    }
}
