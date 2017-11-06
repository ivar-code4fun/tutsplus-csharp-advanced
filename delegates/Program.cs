using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegates
{
    //delegate void MyDelegate(string name);
    delegate void Operation(int number);

    class Program
    {
        static void Main(string[] args)
        {
            //MyDelegate del = new MyDelegate(SayHello);
            //MyDelegate del = SayHello;
            //MyDelegate del = GiveMeMyDelegate();
            //del("John"); //we can even do del.Invoke();
            //Test(del);
            //SayHello("Ravi");

            Operation op = Double;
            ExecuteOperation(2, op);

            op += Triple;  // adding another delegate instead of reassigning
            ExecuteOperation(3, op);

        }

        static void Double(int num)
        {
            Console.WriteLine("{0} * 2 = {1}",num, num * 2);
        }

        static void Triple(int num)
        {
            Console.WriteLine("{0} * 3 = {1}", num, num * 3);
        }

        static void ExecuteOperation(int number, Operation op)
        {
            op(number);
        }

        //static void SayHello(string name)
        //{
        //    Console.WriteLine("Hey There {0}!!", name);
        //}

        //static void Test(MyDelegate del)
        //{
        //    del("John");
        //}

        //static MyDelegate GiveMeMyDelegate()
        //{
        //    return new MyDelegate(SayHello);
        //}
    }
}
