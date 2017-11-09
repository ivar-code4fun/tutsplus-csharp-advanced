using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task_parallel_library
{
    class Program
    {
        static void Main(string[] args)
        {
            //older syntax
            //var t1 = new Task(() => DoWork(1,1500) );
            //t1.Start();


            //Task Factory
            var t1 = Task.Factory.StartNew(() => DoWork(1, 1500)).ContinueWith((prevTask) => DoMoreWork(1, 1000));
            var t2 = Task.Factory.StartNew(() => DoWork(2, 3000));
            var t3 = Task.Factory.StartNew(() => DoWork(3, 1000));

            //Task wait
            var taskList = new List<Task> { t1, t2, t3 };
            Task.WaitAll(taskList.ToArray());

            //parallel foreach
            var intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
            //numbers may not be printed in sequence
            Parallel.ForEach(intList, (i) => Console.WriteLine(i));

            //Parallel.For(0, 100, (i) => Console.WriteLine(i));

            //Task Cancellation Tokens
            var source = new CancellationTokenSource();
            try
            {
                var t4 = Task.Factory.StartNew(() => DoInterruptableWork(4, 1200, source.Token))
                                                    .ContinueWith((prevWork) => DoMoreWork(4, 3000));

                source.Cancel();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType());
            }  


            Console.WriteLine("Press any key to quit");
            Console.ReadLine();
        }

        static void DoWork(int id, int sleepTime)
        {
            Console.WriteLine("Task {0} is beginning", id);
            Thread.Sleep(sleepTime);
            Console.WriteLine("Task {0} has completed", id);
        }

        static void DoMoreWork(int id, int sleepTime)
        {
            Console.WriteLine("Task {0} is beginning more work", id);
            Thread.Sleep(sleepTime);
            Console.WriteLine("Task {0} has completed more work", id);
        }

        static void DoInterruptableWork(int id, int sleepTime, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Cancellation requested");
                token.ThrowIfCancellationRequested();
            }
            Console.WriteLine("Task {0} is beginning", id);
            Thread.Sleep(sleepTime);
            Console.WriteLine("Task {0} has completed", id);
        }
    }
}
