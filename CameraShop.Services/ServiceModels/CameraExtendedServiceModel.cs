using CameraShop.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CameraShop.Services.ServiceModels
{
    public class CameraExtendedServiceModel : CameraServiceModel
    {
        [Range(1, 30)]
        [Display(Name = "Min Shutter Speed")]
        public int MinShutterSpeed { get; set; }

        [Range(2000, 8000)]
        [Display(Name = "Max Shutter Speed")]
        public int MaxShutterSpeed { get; set; }

        [Range(50, 100)]
        [Display(Name = "Min ISO")]
        public MinISO MinISO { get; set; }

        [Range(200, 409600)]
        [Display(Name = "Max ISO")]
        public int MaxISO { get; set; }

        [Display(Name = "Full Frame")]
        public bool IsFullFrame { get; set; }

        [Range(0, 15)]
        [Display(Name = "Video Resolution")]
        public string VideoResolution { get; set; }

        [Display(Name = "Light Meterings")]
        public IEnumerable<LightMetering> LightMeterings { get; set; }

        [StringLength(6000, MinimumLength = 5)]
        public string Description { get; set; }

    }
}
