using Microsoft.EntityFrameworkCore;
using PizzaDb.Data;
using PizzaDb.Models;

namespace Series_101_7_1_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using PizzadbContext _pizzadbContext = new PizzadbContext();

            DbSet<Product> products = _pizzadbContext.Products;

            if (products != null)
            {
                foreach (Product prod in products)
                {
                    Console.WriteLine($"Id: {prod.Id} - {prod.Name} - {prod.Price}");

                }
            }
        }
    }
}