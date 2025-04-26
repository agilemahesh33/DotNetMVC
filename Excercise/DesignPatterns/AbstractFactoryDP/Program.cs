namespace AbstractFactoryDP
{
    internal class Program
    {
        //New Way of Implementing using Generics 
        static void Main(string[] args)
        {
            // Create a waiter by specifying preference
            Waiter waiter = new Waiter("Veg");

            // Ask for Pizza and Burger
            IPizza pizza = waiter.GetPizza();
            Console.WriteLine(pizza.Eat());

            IBurger burger = waiter.GetBurger();
            Console.WriteLine(burger.Eat());
        }

        //Simplest and formal way to call
        //static void Main(string[] args)
        //{
        //    Waiter waiter = new Waiter("NonVeg");
        //    IPizza pizza = waiter.GetPizza();
        //    Console.WriteLine(pizza.Eat());
        //    IBurger burger = waiter.GetBurger();
        //    Console.WriteLine(burger.Eat());
        //}

    }
}
