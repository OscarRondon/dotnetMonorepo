using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_101_8_0_DependencyInjection
{
    public interface IOrderManager
    {
        void SubmitOrder(Product product, string creditCardNumber, string expiryDate);
    }

    public class OrderManager : IOrderManager
    {
        private readonly IProductStockRepository _productStockRepositoryDB;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IShippingProcessor _shippingProcessor;

        public OrderManager(
            IProductStockRepository productStockRepositoryDB,
            IPaymentProcessor paymentProcessor,
            IShippingProcessor shippingProcessor
        )
        {
            _productStockRepositoryDB = productStockRepositoryDB;
            _paymentProcessor = paymentProcessor;
            _shippingProcessor = shippingProcessor;
        }

        public void SubmitOrder(Product product, string creditCardNumber, string expiryDate)
        {
            //Check product stock
            if (!_productStockRepositoryDB.IsInStock(product))
            {
                throw new Exception("There is no inventory for this product");
            }

            //Payment
            _paymentProcessor.ChargeCreditCard(creditCardNumber, expiryDate);


            //Ship the product
            _shippingProcessor.MailProduct(product);
        }
    }
}
