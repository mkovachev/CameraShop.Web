using CameraShop.Services.Contracts;
using CameraShop.Services.ServiceModels;
using CameraShop.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CameraShop.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService users;

        public UsersController(IUserService users) => this.users = users;

        [Authorize]
        public IActionResult Profile(string id)
        {
            var user = this.users.GetUserProfile(id);

            return View(new UserServiceModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Cameras = user.Cameras.Select(c => new CameraServiceModel
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    Quantity = c.Quantity,
                    ImageURL = c.ImageURL
                })

            });
        }

        [Authorize(Roles = GlobalConstants.AdministratorRole)]
        public IActionResult All()
        {
            return View(this.users.GetUserSWithRoles());
        }
    }
}