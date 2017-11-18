using System;

namespace CameraShop.Data.Enums
{
    [Flags]
    public enum LightMetering
    {
        Spot = 1,
        CenterWeighted = 2,
        Evaluative = 4
    }
}
