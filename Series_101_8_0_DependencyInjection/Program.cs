using Microsoft.Extensions.DependencyInjection;

namespace Series_101_8_0_DependencyInjection
{
    internal class Program
    {
        public static readonly IServiceProvider Container = new ContainerBuilder().Build();

        static void Main(string[] args)
        {
            var product = string.Empty;
            var orderManager = Container.GetService<IOrderManager>();

            while (product != "exit")
            {
                Console.Write(@"Enter a product:
Keyboard = 0,
Mouse = 1,
Mic = 2,
Speaker = 3
");
                product = Console.ReadLine();
                try
                {
                    if (Enum.TryParse(product, out Product productEnum))
                    {
                        Console.WriteLine("Please enter a valid payment method XXXXXXXXXXXXXXXX;MMYY");
                        var paymentMethod = Console.ReadLine();
                        if (string.IsNullOrEmpty(paymentMethod) || paymentMethod.Split(";").Length != 2)
                            throw new Exception("Invalid payment method");
                        orderManager.SubmitOrder(productEnum, paymentMethod.Split(";")[0], paymentMethod.Split(";")[1]);
                        Console.WriteLine($"{productEnum.ToString()} has been ship");
                    }
                    else
                    {
                        Console.WriteLine("Invalid product");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}