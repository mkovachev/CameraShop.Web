using System.ComponentModel.DataAnnotations;
using CameraShop.Data.Enums;

namespace CameraShop.Services.ServiceModels
{
    public class CameraServiceModel
    {
        public string Id { get; set; }

        public Make Make { get; set; }

        [Required]
        [RegularExpression("^[A-Z0-9-]+$", ErrorMessage = "Model can contain only uppercase letters, digits and dash")]
        public string Model { get; set; }

        [Range(0, double.MaxValue, ErrorMessage ="Price can be max 1 Million")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Range(0, 100)]
        public int Quantity { get; set; }

        public string ImageURL { get; set; }
    }
}
