using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDP
{
    //Complex Object
    public class Address
    {
        public string Street {  get; set; }
        public string City { get; set; }
        public Address(string street, string city)
        {
            Street = street;
            City = city;
        }
        public Address DeepCopy()
        {
            return new Address(Street, City);
        }
    }
    //Prototype Class
    public class Person : ICloneable
    {
        public int Age {  get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public Person(String Name, Address address)
        {
            this.Name = Name;
            this.Address = address;
        }
        public object Clone() // Method of ICloneable
        {
            return this.MemberwiseClone();
        }
        //Shallow Copy (default)
        public Person ShallowClone()  //Object can also be returned
        {
            return new Person(this.Name, this.Address) { Age = this.Age };
        }
        //Deep Copy (Custom)
        public Person DeepClone()
        {
            Person clone = (Person)this.MemberwiseClone();
            clone.Address = this.Address.DeepCopy();// Important: deep clone Address separately
            return clone;   //new Person(Name, Address);
        }
        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Street: {Address.Street},City: {Address.City}");
        }
    }
}
