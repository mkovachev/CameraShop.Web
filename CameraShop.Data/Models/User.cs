using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CameraShop.Data.Models
{
    public class User : IdentityUser
    {
        public IEnumerable<Camera> Cameras { get; set; }
    }
}
