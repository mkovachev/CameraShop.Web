using CameraShop.Web.Infrastructure.Extensions.Filters;
using CameraShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CameraShop.Web.Controllers
{
    public class HomeController : Controller
    {
        [Log]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
