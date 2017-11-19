using CameraShop.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CameraShop.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService users;

        public UsersController(IUserService users) => this.users = users;

        [Authorize]
        public IActionResult Profile(string id) => View(this.users.GetUserProfile(id));
    }
}