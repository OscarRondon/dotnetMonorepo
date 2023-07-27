using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_101_8_0_DependencyInjection
{
    public interface IPaymentProcessor
    {
        void ChargeCreditCard(string creditCardNumber, string expiryDate);
    }

    public class PaymentProcessor : IPaymentProcessor
    {
        public void ChargeCreditCard(string creditCardNumber, string expiryDate)
        {
            if (string.IsNullOrEmpty(creditCardNumber))
            {
                throw new ArgumentException("Invalid Credit Card");
            }

            if (string.IsNullOrEmpty(expiryDate))
            {
                throw new ArgumentException("Invalid expiration date");
            }

            Console.WriteLine("Call credit card API");
        }
    }
}
