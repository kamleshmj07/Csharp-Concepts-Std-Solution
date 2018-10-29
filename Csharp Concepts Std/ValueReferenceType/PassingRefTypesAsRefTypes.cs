using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Concepts_Std.ValueReferenceType
{
    public class Person
    {
        private string _Name;
        private int _Age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int Age { get => _Age; set => _Age = value; }
        public string Name { get => _Name; set => _Name = value; }

        public void Display()
        {
            Console.WriteLine("Person Details => Name : {0}, Age : {1}", this.Name, this.Age);
        }
    }
}
