using Moq;
using Series_101_8_0_DependencyInjection;

namespace Series_101_8_1_DependencyInjectionTests
{
    public class OrderManagerTest
    {
        [Fact]
        public void NoStockException()
        {
            var productStockRepositoryDBMock = new Mock<IProductStockRepository>();
            productStockRepositoryDBMock.Setup(m => m.IsInStock(It.IsAny<Product>())).Returns(false);

            var paymentProcessorMock = new Mock<IPaymentProcessor>();

            var shippingProcessorMock = new Mock<IShippingProcessor>();


            var orderManager = new OrderManager(
                                        productStockRepositoryDBMock.Object,
                                        paymentProcessorMock.Object,
                                        shippingProcessorMock.Object
                                   );

            Assert.ThrowsAny<Exception>(() => orderManager.SubmitOrder(Product.Keyboard, "1111222233334444", "1026"));
        }
    }
}