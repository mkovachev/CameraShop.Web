using CameraShop.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CameraShop.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService users;

        public UsersController(IUserService users) => this.users = users;

        public IActionResult UserProfile(string id) => View(this.users.GetUserProfile(id));
    }
}