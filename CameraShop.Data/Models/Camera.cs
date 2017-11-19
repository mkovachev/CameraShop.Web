using CameraShop.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace CameraShop.Data.Models
{
    public class Camera
    {
        public string Id { get; set; }

        public Make Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Range(0, 100)]
        public int Quantity { get; set; }

        [Range(1, 30)]
        public int MinShutterSpeed { get; set; }

        [Range(2000, 8000)]
        public int MaxShutterSpeed { get; set; }

        [Range(50, 100)]
        public MinISO MinISO { get; set; }

        [Range(200, 409600)]
        public int MaxISO { get; set; }

        public bool IsFullFrame { get; set; }

        [MaxLength(15)]
        public string VideoResolution { get; set; }

        public LightMetering LightMetering { get; set; }

        [Required]
        [MaxLength(6000)]
        public string Description { get; set; }

        [MinLength(10)]
        [MaxLength(2000)]
        public string ImageURL { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

    }
}