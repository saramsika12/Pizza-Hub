using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Services.Interfaces
{
    public interface IPaymentService
	{
		/// <summary>
		/// Generates the signature for secure eSewa transactions.
		/// </summary>
		/// <param name="totalAmount">Total payment amount</param>
		/// <param name="productCode">Unique product code</param>
		/// <param name="transactionUuid">Transaction UUID</param>
		/// <returns>Generated signature string</returns>
		string GenerateESewaSignature(decimal totalAmount, string productCode, string transactionUuid);

		/// <summary>
		/// Constructs the payment URL with all required parameters.
		/// </summary>
		/// <param name="amount">Payment amount</param>
		/// <param name="tax">Tax amount</param>
		/// <param name="productCode">Product code</param>
		/// <param name="transactionUuid">Transaction UUID</param>
		/// <returns>eSewa payment gateway URL</returns>
		string GetPaymentUrl(decimal amount, decimal tax, string productCode, string transactionUuid);
	}
}
