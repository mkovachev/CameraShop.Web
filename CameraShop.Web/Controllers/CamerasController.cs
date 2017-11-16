using CameraShop.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CameraShop.Web.Controllers
{
    public class CamerasController : Controller
    {
        private readonly ICameraService cameras;

        public CamerasController(ICameraService cameras) => this.cameras = cameras;

        public IActionResult All()
        {
            return View(this.cameras.GetAll());
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
    }
}