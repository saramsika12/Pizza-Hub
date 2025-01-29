using Microsoft.AspNetCore.Mvc;
using PizzaHub.Services.Interfaces;

namespace PizzaHub.WebUI.ViewComponents
{
    public class PizzaMenuViewComponent: ViewComponent
    {
        ICatalogService _catalogService;
        public PizzaMenuViewComponent(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }
        public IViewComponentResult Invoke()
        {
            var items = _catalogService.GetItems();
            return View("~/Views/Shared/_PizzaMenu.cshtml", items);
        }
    }
}
