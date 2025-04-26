using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDP
{
    public interface IPizza //IproductA
    {
        string Eat();
    }
    //Concrete Implementation VegPizza
    class VegPizza : IPizza //ConcreteProduct1A
    {
        public string Eat()
        {
            return "Eating Veg Pizza !!!!";
        }
    }
    //Concrete Implementation NonVegPizza
    class NonVegPizza : IPizza //ConcreteProduct2A
    {
        public string Eat()
        {
            return "Eating NonVeg Pizza ): ";
        }
    }
    public interface IPizzaChef //Factory
    {
        IPizza PreparePizza();
    }
    class VegPizzaChef : IPizzaChef
    {
        public IPizza PreparePizza()
        {
            return new VegPizza();
        }
    }
    class NonVegPizzaChef : IPizzaChef
    {
        public IPizza PreparePizza()
        {
            return new NonVegPizza();
        }
    }
    //
    public interface IBurger //IproductB
    {
        string Eat();
    }
    //Concrete Implementation VegBurger
    class VegBurger : IBurger //ConcreteProduct1B
    {
        public string Eat()
        {
            return "Eating Veg Burger !!!!";
        }
    }
    //Concrete Implementation NonVegBurger
    class NonVegBurger : IBurger //ConcreteProduct2B
    {
        public string Eat()
        {
            return "Eating NonVeg Burger ): ";
        }
    }
    public interface IBurgerChef //Factory
    {
        IBurger PrepareBurger();
    }
    class VegBurgerChef : IBurgerChef
    {
        public IBurger PrepareBurger()
        {
            return new VegBurger();
        }
    }
    class NonVegBurgerChef : IBurgerChef
    {
        public IBurger PrepareBurger()
        {
            return new NonVegBurger();
        }
    }
    interface IChef //Factory
    {
        IPizza PreparePizza();
        IBurger PrepareBurger();
    }
    //Products
    class VegChef : IChef
    {
        public IPizza PreparePizza()
        {
            return new VegPizza();
        }
        public IBurger PrepareBurger()
        {
            return new VegBurger();
        }
    }
    //Products
    class NonVegChef : IChef
    {
        public IBurger PrepareBurger()
        {
            return new NonVegBurger();
        }

        public IPizza PreparePizza()
        {
            return new NonVegPizza();
        }
    }
    //New Way of Implementing using Generics 
    class Waiter
    {
        private static readonly Dictionary<string, Func<IChef>> chefs = new()
        {
            { "Veg", () => new VegChef() },
            { "NonVeg", () => new NonVegChef() }
        };

        private IChef foodFactory;

        public Waiter(string preference)
        {
            if (!chefs.TryGetValue(preference, out var chefFactory))
                throw new ArgumentException("Unknown preference: " + preference);
            foodFactory = chefFactory();
        }

        public IPizza GetPizza()
        {
            return foodFactory.PreparePizza();
        }

        public IBurger GetBurger()
        {
            return foodFactory.PrepareBurger();
        }
    }

    //Simplest and formal way to call
    //class Waiter
    //{
    //    private IChef foodFactory;
    //    public Waiter(string preference)
    //    {
    //        if (preference == "Veg")
    //            foodFactory = new VegChef();
    //        else
    //            foodFactory = new NonVegChef();
    //    }
    //    public IPizza GetPizza()
    //    {
    //        return foodFactory.PreparePizza();
    //    }
    //    public IBurger GetBurger()
    //    {
    //        return foodFactory.PrepareBurger();
    //    }
    //}
}
