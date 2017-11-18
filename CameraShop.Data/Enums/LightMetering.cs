using System;
using System.ComponentModel.DataAnnotations;

namespace CameraShop.Data.Enums
{
    [Flags]
    public enum LightMetering
    {
        Spot = 1,
        [Display(Name = "Center Weighted")]
        CenterWeighted = 2,
        Evaluative = 4
    }
}
