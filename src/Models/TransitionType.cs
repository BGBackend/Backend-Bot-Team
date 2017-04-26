using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuisBot.Models
{
    public enum TransitionType
    {
        None = -1,
        New = 0,
        TrialConversion = 1,
        ManualRenew = 2,
        AutoRenew = 3,
        Upgrade = 4,
        UpgradeRenew = 5,
        SecondTrial = 6,
        ChangeProduct = 7,
        UpgradeLicence = 8
    }
}