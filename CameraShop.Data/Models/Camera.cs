using CameraShop.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace CameraShop.Data.Models
{
    public class Camera
    {
        public int Id { get; set; }

        public Make Make { get; set; }

        [Required]
        [RegularExpression("\b[A-Z0-9]+(?:-[A-Z0-9]+)+", ErrorMessage = "Model can contain only uppercase letters, digits and dash")]
        public string Model { get; set; }

        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Range(0, 100)]
        public int Quantity { get; set; }

        [Range(1, 30)]
        public byte MinShutterSpeed { get; set; }

        [Range(2000, 8000)]
        public int MaxShutterSpeed { get; set; }

        [Range(50, 100)]
        public byte MinISO { get; set; }

        [Range(200, 409600)]
        public byte MaxISO { get; set; }

        [Display(Name ="Full Frame")]
        public bool IsFullFrame { get; set; }

        [MaxLength(15, ErrorMessage ="Video Resolution cannot be longer than 15 symbols")]
        [Display(Name = "Video Resolution")]
        public string VideoResolution { get; set; }

        public LightMetering LightMetering { get; set; }

        [MaxLength(6000, ErrorMessage = "Description cannot be more than 6000 symbols")]
        public string Description { get; set; }

        public ImageURL ImageURL { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

    }
}
