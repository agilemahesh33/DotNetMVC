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
            Person shallowCopy = (Person)original.ShallowClone();

            // Deep copy
            Person deepCopy = original.DeepClone();

            Console.WriteLine("Before Modification:");
            Console.WriteLine("Original");
            original.Display();
            Console.WriteLine("Shallow");
            shallowCopy.Display();
            Console.WriteLine("Deep");
            deepCopy.Display();

            // Modify original object's Address
            original.Address.Street = "999 Changed St";

            Console.WriteLine("\nAfter Modification:");
            Console.WriteLine("Original");
            original.Display();      // Address changed
            Console.WriteLine("Shallow");
            shallowCopy.Display();   // Address also changed (because of shallow copy)
            Console.WriteLine("Deep");
            deepCopy.Display();      // Address NOT changed (because of deep copy)

            Console.ReadKey();
        }
    }
}
