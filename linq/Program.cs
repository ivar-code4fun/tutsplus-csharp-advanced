using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringManipulationLinq();

            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", Age = 25 },
                new Person { FirstName = "Jane", LastName = "Doe", Age = 26 },
                new Person { FirstName = "John", LastName = "Wiliams", Age = 40 },
                new Person { FirstName = "Samantha", LastName = "Wiliams", Age = 34 },
                new Person { FirstName = "Bob", LastName = "Walters", Age = 12 },
            };

            var results = from p in people
                              //where p.Age < 30 && p.LastName == "Doe"
                              //orderby p.LastName descending
                          group p by p.LastName;
                          //select p;

            foreach (var item in results)
            {
                //Console.WriteLine("{0} - {1}",item.LastName, item.FirstName);
                Console.WriteLine(item.Key + " - " + item.Count());
                foreach (var p in item)
                {
                    Console.WriteLine("\t" + p.LastName + " : " + p.FirstName);
                }
            }

        }

        private static void StringManipulationLinq()
        {
            var sample = "I enjoy writing uber-software in C#";

            var result = from c in sample.ToLower()
                         where c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'
                         orderby c descending
                         group c by c;
            //select c;

            foreach (var item in result)
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Count());
            }
        }

    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
