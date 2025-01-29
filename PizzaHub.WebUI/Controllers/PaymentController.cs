using Microsoft.AspNetCore.Mvc;
using PizzaHub.Repositories.Models;
using PizzaHub.Services.Interfaces;
using PizzaHub.WebUI.Helpers;
using PizzaHub.WebUI.Models;
using System;

namespace PizzaHub.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            PaymentModel payment = new PaymentModel();
            CartModel cart = TempData.Peek<CartModel>("Cart");
            if (cart != null)
            {
                payment.Cart = cart;
            }
            payment.GrandTotal = Math.Round(cart.GrandTotal);
            payment.Currency = "NPR";
            string items = "";
            foreach (var item in cart.Items)
            {
                items += item.Name + ",";
            }
            payment.Description = items;

            return View(payment);
        }
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public IActionResult Checkout()
        {
            // Sample data - replace with actual cart data
            decimal amount = 1000m;
            decimal tax = 50m;
            string productCode = "EPAYTEST";
            string transactionUuid = Guid.NewGuid().ToString();

            string paymentUrl = _paymentService.GetPaymentUrl(amount, tax, productCode, transactionUuid);
            return Redirect(paymentUrl);
        }

		public IActionResult Success()
		{
			return View("PaymentSuccess");
		}
		public IActionResult Failure()
		{
			return View("PaymentFailure");
		}
	}
}
