using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extension_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person { Name = "John", Age = 33 };
            var p2 = new Person { Name = "Jane", Age = 27 };
            p1.SayHello(p2);

        }
    }

    public static class Extensions
    {
        public static void SayHello(this Person person1, Person person2)
        {
            Console.WriteLine("{0} says hello to {1} ",person1.Name, person2.Name);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
