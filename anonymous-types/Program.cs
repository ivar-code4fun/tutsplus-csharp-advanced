using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymous_types
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>
            {
                new Person { FirstName="John", LastName="Doe", Age = 20 },
                new Person { FirstName="Jane", LastName="Doe", Age = 30 },
                new Person { FirstName="Billy", LastName="Johnson", Age = 15 },
                new Person { FirstName="Sally", LastName="Johnson", Age = 17 },
                new Person { FirstName="Rupert", LastName="LastName", Age = 55 },
            };

            var result = from p in people
                         where p.LastName == "Doe"
                         select new { FName = p.FirstName, LName = p.LastName };

            foreach (var p in result)
            {
                Console.WriteLine(p.FName + " " + p.LName);
            }
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
        public int MyProperty3 { get; set; }
    }
}
