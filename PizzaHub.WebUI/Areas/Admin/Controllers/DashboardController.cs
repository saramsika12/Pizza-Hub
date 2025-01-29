using Microsoft.AspNetCore.Mvc;

namespace PizzaHub.WebUI.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
