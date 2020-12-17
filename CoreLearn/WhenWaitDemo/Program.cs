using System;
using System.Threading.Tasks;

namespace WhenWaitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("run");
            Task task1 = Task.Factory.StartNew(() =>
           {
               Console.WriteLine("1000");
           });
            Task task2 = Task.Factory.StartNew(() =>
           {
               Console.WriteLine("2000");
           });

            Task task3 = Task.Factory.StartNew(() =>
          {
              Task.Delay(1000).Wait();
              Console.WriteLine("3000");
          });

            Task task4 = new Task(() =>
            {
                Task.Delay(100).Wait();
                Console.WriteLine("4000");
            });

            Console.WriteLine("a");
            task4.Start();
            Console.WriteLine("c");
            Console.WriteLine();
            Task.WhenAll(new Task[] { task1, task2, task3
            });

            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
