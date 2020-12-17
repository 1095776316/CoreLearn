using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace ObservableDemo
{
    class Program
    {
        static int i = 10;
        static void Main(string[] args)
        {
            Observable.Interval(TimeSpan.FromSeconds(1))
       .Timestamp()
       .Where(x => x.Value % 2 == 0)
       .Select(x => x.Timestamp)
       .Subscribe(x => Trace.WriteLine("i"+x.DateTime.ToString()),
           ex => Trace.WriteLine(ex));

            //string name = "张三";
            //var invokeServerObservable = Observable.Defer(() =>
            //    GetValueAsync(name).ToObservable());
            //invokeServerObservable.Subscribe(p => { Console.WriteLine(p); });
            //invokeServerObservable.Subscribe(p => { Console.WriteLine(p); });
            //Console.WriteLine("...");
            Console.ReadKey();
        }

        static async Task<int> GetValueAsync(string name)
        {
            Console.WriteLine($"{name}:Call Server...");
            await Task.Delay(1000);
            Console.WriteLine($"{name}:Returning Result...");
            i++;
            return i;
        }
    }
}
