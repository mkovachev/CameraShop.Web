using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CameraShop.Services.ServiceModels
{
    public class UserServiceModel
    {
        public string Id { get; set; }

        [Required]
        [Range(4, 20)]
        [RegularExpression("[A-Za-z]", ErrorMessage = "Name can contain only letters")]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Phone")]
        public string PhoneNumber { get; set; }

        public IEnumerable<CameraServiceModel> Cameras { get; set; }
    }
}
    