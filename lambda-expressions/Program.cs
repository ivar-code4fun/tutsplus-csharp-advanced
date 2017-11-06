using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambda_expressions
{
    //delegate void Operation(int number);

    class Program
    {
        static void Main(string[] args)
        {
            //Generic delegates
            //Action<> - no return value
            //Func<> - return value
            //Operation op = num => { Console.WriteLine("{0} * 2 = {1}", num, num * 2); };
            //Action<int> op = num => { Console.WriteLine("{0} * 2 = {1}", num, num * 2); };
            Action<int> op = num => Square(num);
            op(2);

            Func<int, int> op1 = num => Cube(num);
            var result = op1(4);
            Console.WriteLine("Cube of {0} is {1}", 4, result);
        }

        static void Square(int num)
        {
            Console.WriteLine("Square of {0} is {1}", num, num * num);
        }

        static int Cube(int num)
        {
            return num * num * num;
        }
    }
}
