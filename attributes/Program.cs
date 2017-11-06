using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            var types = from t in Assembly.GetExecutingAssembly().GetTypes()
                        where t.GetCustomAttributes<SampleAttribute>().Count() > 0
                        select t;

            foreach (var type in types)
            {
                Console.WriteLine("Type = " + type);

                foreach (var p in type.GetProperties())
                {
                    Console.WriteLine("Property = " + p.Name);
                }

                foreach (var m in type.GetMethods())
                {
                    Console.WriteLine("Method = " + m.Name);
                }
            }


        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class SampleAttribute : Attribute
    {
        public string Name { get; set; }
        public int Version { get; set; }
    }

    [Sample(Name = "John",Version = 1)]
    public class Test
    {
        public int IntValue { get; set; }

        public void Method() { }
    }

    public class NoAttribute
    {

    }
}
