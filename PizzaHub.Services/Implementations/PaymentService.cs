using PizzaHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Services.Implementations
{
	public class PaymentService : IPaymentService
	{
		private const string _secretKey = "8gBm/:&EnhH.1/q"; // Replace with your actual secret key
		private const string _baseUrl = "https://rc-epay.esewa.com.np/api/epay/main/v2/form";
		private const string _successUrl = "https://yourdomain.com/payment/success";
		private const string _failureUrl = "https://yourdomain.com/payment/failure";

		public string GenerateESewaSignature(decimal totalAmount, string productCode, string transactionUuid)
		{
			string data = $"{totalAmount}{productCode}{transactionUuid}";
			using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_secretKey)))
			{
				byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
				return Convert.ToBase64String(hashBytes);
			}
		}

		public string GetPaymentUrl(decimal amount, decimal tax, string productCode, string transactionUuid)
		{
			decimal totalAmount = amount + tax;
			string signature = GenerateESewaSignature(totalAmount, productCode, transactionUuid);

			string paymentUrl = $"{_baseUrl}?" +
				$"amount={amount}&tax_amount={tax}&total_amount={totalAmount}" +
				$"&product_code={productCode}&transaction_uuid={transactionUuid}" +
				$"&success_url={_successUrl}&failure_url={_failureUrl}&signature={signature}";

			return paymentUrl;
		}
	}
}
