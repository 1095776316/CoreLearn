using System;
using System.Linq;
using System.Threading.Tasks;

namespace Unit3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Action action = () => Console.WriteLine(DateTime.Now.Second.ToString() + "-" + DateTime.Now.Millisecond.ToString());
            DoAction20Times(action);
            Task.Delay(1000).Wait();
            Console.WriteLine(i);
            Console.ReadKey();
        }

        static void DoAction20Times(Action action)
        {
            Action[] actions = Enumerable.Repeat(action, 20).ToArray();
            Parallel.Invoke(actions);
        }
    }
}
