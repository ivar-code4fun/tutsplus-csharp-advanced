using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //var assembly = Assembly.GetExecutingAssembly();

            //Console.WriteLine(assembly.FullName);

            //var types = assembly.GetTypes();
            //foreach (var type in types)
            //{
            //    Console.WriteLine("Type : " + type.Name + " BaseType : " + type.BaseType );

            //    var props = type.GetProperties();
            //    foreach (var prop in props)
            //    {
            //        Console.WriteLine("\tProperty: " + prop.Name + " PropertyType " + prop.PropertyType);
            //    }

            //    var methods = type.GetMethods();
            //    foreach (var method in methods)
            //    {
            //        Console.WriteLine("\tMethod: " + method);
            //    }

            //}

            //var sample = new Sample { Name = "John", Age = 25 };
            //var sampleType = typeof(Sample);

            //var nameProperty = sampleType.GetProperty("Name");
            //Console.WriteLine("Property : " + nameProperty.GetValue(sample));

            //var myMethod = sampleType.GetMethod("MyMethod");
            //myMethod.Invoke(sample, null);

            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes().Where(t => t.GetCustomAttributes<MyClassAttribute>().Count() > 0);

            foreach (var type in types)
            {
                Console.WriteLine(type);

                var methods = type.GetMethods().Where(m => m.GetCustomAttributes<MyMethodAttribute>().Count() > 0);

                foreach (var method in methods)
                {
                    Console.WriteLine(method.Name);
                }
            }
        }
    }

    [MyClass]
    public class Sample
    {
        public string Name { get; set; }
        public int Age { get; set; }

        [MyMethod]
        public void MyMethod()
        {
            Console.WriteLine("Hello from My Method which ill invoke thru reflection!");
        }

        public void NoAttribute()
        {
            Console.WriteLine("This should not show up when filtered by attribute!");
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class MyClassAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class MyMethodAttribute : Attribute
    {

    }
}
