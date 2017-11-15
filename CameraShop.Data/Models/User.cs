using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CameraShop.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<Camera> Cameras { get; set; } = new HashSet<Camera>();
    }
}
