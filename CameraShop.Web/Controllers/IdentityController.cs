using CameraShop.Services.Contracts;
using CameraShop.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CameraShop.Web.Controllers
{
    
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class IdentityController : Controller
    {
        private readonly IUserService users;

        public IdentityController(IUserService users) => this.users = users;

        public IActionResult All()
        {
            return View(this.users.GetUserSWithRoles());
        }
    }
}