using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_101_8_0_DependencyInjection
{
    public class ContainerBuilder
    {
        public IServiceProvider Build()
        {
            var container = new ServiceCollection();

            container.AddSingleton<IOrderManager, OrderManager>();
            container.AddSingleton<IProductStockRepository, ProductStockRepository>();
            container.AddSingleton<IPaymentProcessor, PaymentProcessor>();
            container.AddSingleton<IShippingProcessor, ShippingProcessor>();

            return container.BuildServiceProvider();
        }
    }
}
