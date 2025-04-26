using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDP
{
    public interface IPizza //Iproduct
    {
        string Eat();
    }
    //Concrete Implementation VegPizza
    class VegPizza : IPizza
    {
        public string Eat()
        {
            return "Eating Veg Pizza !!!!";
        }
    }
    //Concrete Implementation NonVegPizza
    class NonVegPizza : IPizza
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

    class Waiter //Client Class 
    {
        public IPizza GetPizza(string type)
        {
            IPizzaChef chef;
            switch (type)
            {
                case "Veg":
                    chef = new VegPizzaChef();
                    break;
                case "NonVeg":
                    chef = new NonVegPizzaChef();
                    break;
                default:
                    throw new ArgumentException("Invalid pizza type");
            }
            return chef.PreparePizza();
        }
    }
}
