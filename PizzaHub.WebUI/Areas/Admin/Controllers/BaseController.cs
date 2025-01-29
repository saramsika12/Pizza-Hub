using Microsoft.AspNetCore.Mvc;
using PizzaHub.WebUI.Helpers;

namespace PizzaHub.WebUI.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    [Area("Admin")]
    public class BaseController : Controller
    {
        
    }
}
