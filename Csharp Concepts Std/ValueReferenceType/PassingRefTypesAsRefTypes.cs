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

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        public int Age
        {
            get
            {
                return _Age;
            }

            set
            {
                _Age = value;
            }
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public void Display()
        {
            Console.WriteLine("Person Details => Name : {0}, Age : {1}", this.Name, this.Age);
        }
    }
}
