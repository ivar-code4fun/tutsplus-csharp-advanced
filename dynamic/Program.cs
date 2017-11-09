using IronPython.Hosting;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            var pythonRuntime = Python.CreateRuntime();

            dynamic pythonFile = pythonRuntime.UseFile("Test.py");

            pythonFile.SayHelloToPython();

            dynamic test = new ExpandoObject();

            test.Name = "John";
            test.Age = 35;


            Console.WriteLine("Age of " + test.Name + " is " + test.Age);
            Console.WriteLine();
        }
    }
}
