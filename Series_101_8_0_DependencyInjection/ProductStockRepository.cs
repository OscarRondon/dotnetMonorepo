using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_101_8_0_DependencyInjection
{
    public interface IProductStockRepository
    {
        void AddStock(Product product);
        bool IsInStock(Product product);
        void ReduceStock(Product product);
    }

    public class ProductStockRepository : IProductStockRepository
    {
        private static Dictionary<Product, int> _productStockDB = Setup();
        private static Dictionary<Product, int> Setup()
        {
            var productStockDB = new Dictionary<Product, int>();
            productStockDB.Add(Product.Keyboard, 1);
            productStockDB.Add(Product.Mouse, 1);
            productStockDB.Add(Product.Mic, 1);
            productStockDB.Add(Product.Speaker, 1);

            return productStockDB;
        }

        public bool IsInStock(Product product)
        {
            Console.WriteLine("Call get on DB");
            return _productStockDB[product] > 0;
        }

        public void ReduceStock(Product product)
        {
            Console.WriteLine("Call update on DB");
            --_productStockDB[product];
        }

        public void AddStock(Product product)
        {
            Console.WriteLine("Call update on DB");
            ++_productStockDB[product];
        }
    }
}
