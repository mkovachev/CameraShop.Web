using CameraShop.Data.Models;
using CameraShop.Services.Contracts;
using CameraShop.Services.ServiceModels;
using CameraShop.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CameraShop.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService users;
        private readonly UserManager<User> userManager;

        public UsersController(IUserService users, UserManager<User> userManager)
        {
            this.users = users;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create() => View();

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateUserServiceModel model) => View();

        [Authorize]
        public IActionResult Profile(string id)
        {
            return View(this.users.GetUserProfile(id));
        }

        [Authorize(Roles = GlobalConstants.AdministratorRole)]
        public async Task<IActionResult> All() // TODO
        {
            var usersWithRoles = await this.userManager.GetUsersInRoleAsync("Administrator");

            return View(this.users.GetUserSWithRoles());
        }

        // no view created yet
        public async Task<IActionResult> GetRoles(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var roles = await this.userManager.GetRolesAsync(user);

            return View(roles);
        }
    }
}