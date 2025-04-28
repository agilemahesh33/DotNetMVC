using System.Net;
using System;

namespace PrototypeDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Original object
            Person original = new Person("John Doe", new Address("123 Main St", "New York"));

            // Shallow copy
            Person shallowCopy = (Person)original.Clone();

            // Deep copy
            Person deepCopy = original.DeepClone();

            Console.WriteLine("Before Modification:");
            original.Display();
            shallowCopy.Display();
            deepCopy.Display();

            // Modify original object's Address
            original.Address.Street = "999 Changed St";

            Console.WriteLine("\nAfter Modification:");
            original.Display();      // Address changed
            shallowCopy.Display();   // Address also changed (because of shallow copy)
            deepCopy.Display();      // Address NOT changed (because of deep copy)

            Console.ReadKey();
        }
    }
}
