using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generics
{
    class Program
    {
        static void Main(string[] args)
        {
            //call a service or DAL
            //var result = new ResultInt { Success = true, Data = 5 };

            //var result2 = new ResultString { Success = false, Data = "John" };

            var result = new Result<int> { Success = true, Data = 10, Data2 = 50 };
            var result2 = new Result<string> { Success = false, Data = "John", Data2 = "Doe" };
            Console.WriteLine(result2.Success);
            Console.WriteLine(result2.Data);
            Console.WriteLine(result2.Data2);

            var helper = new ResultPrinter();
            helper.Print(result);
            helper.Print(result2); //-- This will not work as the generic overload is an int
        }
    }

    public class Result<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public T Data2 { get; set;  }
    }

    public class ResultPrinter
    {
        public void Print<T>(Result<T> result)
        {
            Console.WriteLine("From result printer : " + result.Success);
            Console.WriteLine("From result printer : " + result.Data);
        }
    }

    //public class ResultInt
    //{
    //    public bool Success { get; set; }
    //    public int Data { get; set; }
    //}

    //public class ResultString
    //{
    //    public bool Success { get; set; }
    //    public string Data { get; set; }
    //}
}
