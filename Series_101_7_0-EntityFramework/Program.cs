using Series_101_7_0_EntityFramework.Data;
using Series_101_7_0_EntityFramework.Models;


namespace Series_101_7_0_EntityFramework
{
    internal class Program
    {
    static void Main(string[] args)
        {
            using PizzaDBContext context = new PizzaDBContext();
            // Add an Entity
            //Product veggieSpecial = new Product()
            //{
            //    Name = "Veggie Special Pizza",
            //    Price = 9.99M
            //};
            //context.Product.Add(veggieSpecial);

            //Product deluxeMeat = new Product()
            //{
            //    Name = "Deluxe Meat Pizza",
            //    Price = 12.99M
            //};
            //context.Product.Add(deluxeMeat);


            //context.SaveChanges();


            
            var veggieSpecial = context.Product.Where(p => p.Name == "Veggie Special Pizza").FirstOrDefault();

            //Update an Entity
            if (veggieSpecial is Product)
            {
                veggieSpecial.Price = 10.99M;
            }

            //Delete an Entity
            if (veggieSpecial is Product)
            {
                context.Remove(veggieSpecial);
            }
            context.SaveChanges();

            var products = context.Product.Where(p => p.Price > 10.00M).OrderBy(p => p.Name);

            //This line of code its equivalent with the above
            var products2 = from p in context.Product where p.Price > 10.00M orderby p.Name  select p;

            foreach(Product prod in products) {
                Console.WriteLine($"Id: {prod.Id}");
                Console.WriteLine($"Name: {prod.Name}");
                Console.WriteLine($"Price: {prod.Price}");
                Console.WriteLine(new string('-',20));
            }

            foreach (Product prod in products2)
            {
                Console.WriteLine($"Id: {prod.Id}");
                Console.WriteLine($"Name: {prod.Name}");
                Console.WriteLine($"Price: {prod.Price}");
                Console.WriteLine(new string('-', 20));
            }
        }
    }
}