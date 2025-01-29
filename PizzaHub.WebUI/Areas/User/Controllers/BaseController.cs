using Microsoft.AspNetCore.Mvc;
using PizzaHub.WebUI.Helpers;

namespace PizzaHub.WebUI.Areas.User.Controllers
{
    [CustomAuthorize(Roles = "User")]
    [Area("User")]
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
