using PizzaHub.Repositories.Models;

namespace PizzaHub.WebUI.Models
{
    public class PaymentModel
    {
		public string Name { get; set; } // Payer's name
		public string EpayMerchantCode { get; set; } // Merchant code for eSewa
		public decimal GrandTotal { get; set; } // Total payment amount
		public string Description { get; set; } // Payment description
		public string Currency { get; set; } // Currency type, e.g., NPR
		public string TransactionId { get; set; } // Unique transaction ID
		public CartModel Cart { get; set; } // Cart details
		public string SuccessUrl { get; set; } // Success redirect URL
		public string FailureUrl { get; set; } // Failure redirect URL
		public string ProductId { get; set; } // Unique product/order ID for eSewa
	}
}
