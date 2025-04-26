namespace FactoryDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Waiter waiter = new Waiter();
            IPizza pizza = waiter.GetPizza("Veg");
            Console.WriteLine(pizza.Eat());

            pizza = waiter.GetPizza("NonVeg");
            Console.WriteLine(pizza.Eat());

            //pizza = waiter.GetPizza("MashroomVeg"); //Will Throw Exception
            //Console.WriteLine(pizza.Eat());
            
            //Or

            Console.WriteLine("Enter the type of pizza (Veg/NonVeg):");
            Console.WriteLine(waiter.GetPizza(Console.ReadLine()).Eat());
        }
    }
}
