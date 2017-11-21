using CameraShop.Services.Contracts;
using CameraShop.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CameraShop.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService users;

        public UsersController(IUserService users) => this.users = users;

        [Authorize]
        public IActionResult Profile(string id)
        {
            return View(this.users.GetUserProfile(id));
        }

        [Authorize(Roles = GlobalConstants.AdministratorRole)]
        public IActionResult All()
        {
            return View(this.users.GetUserSWithRoles());
        }
    }
}