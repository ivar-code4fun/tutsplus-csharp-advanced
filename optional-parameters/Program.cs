using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optional_parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintData("John",age: 35);
            PrintData(firstName: "Ravi", lastName: "Shankar", age: 40);

        }

        static void PrintData(string firstName, int age, string lastName = "Doe")
        {
            Console.WriteLine("{0} {1} is {2} years old",firstName,lastName,age);
        }
    }
}
