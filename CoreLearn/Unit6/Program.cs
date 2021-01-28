using System;
using System.Net;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Unit6
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Test0123();
            await Task.Delay(1000);
            Console.ReadKey();
        }


        static void Test0123()
        {
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Window(2)
                //.Buffer(1)
                .Subscribe(group => { group.Subscribe(x => Console.WriteLine(x)); }); ;
        }

        static void Test0101()
        {
            int i = 1;
            Progress<int> progress = new Progress<int>();
            IObservable<EventPattern<int>> progressReport = Observable.FromEventPattern<int>(
                handler => progress.ProgressChanged += handler,
                handler => progress.ProgressChanged -= handler);
            progressReport.Subscribe(data => i++);
            Task.Delay(1000).Wait();
            Console.WriteLine(i);
        }

        static void Test0102()
        {
            var timer = new Timer(interval: 1000) { Enabled = true };
            IObservable<EventPattern<ElapsedEventArgs>> ticks =
                Observable.FromEventPattern<ElapsedEventHandler, ElapsedEventArgs>(
                    handler => (s, a) => handler(s, a),
                    handler => timer.Elapsed += handler,
                    handler => timer.Elapsed -= handler
                    );
            ticks.Subscribe(data => Console.WriteLine($"OnNext:{data.EventArgs.SignalTime}")); ;
        }

        static void Test0104()
        {
            var client = new System.Net.WebClient();
            //IObservable<EventPattern<object>> downloadString = Observable.FromEventPattern(client, nameof(client.DownloadStringCompleted));
            //downloadString.Subscribe(
            //    data =>
            //    {
            //        var eventArgs = (DownloadStringCompletedEventArgs)data.EventArgs;
            //        Console.WriteLine("Call Someone I download");
            //    },
            //    ex => Console.WriteLine("OnError:" + ex.Message),
            //    () => { Console.WriteLine("=============================================================Completed"); }
            //    );
            client.DownloadStringCompleted += (e, s) => { Console.WriteLine("hhh"); };
            client.DownloadStringAsync(new Uri("http://www.baidu.com"));

        }

        static async void Test0603()
        {
            Demo demo = new Demo();
            IObservable<EventPattern<object>> observable = Observable.FromEventPattern(demo, nameof(demo));
            observable.Subscribe(data =>
            {
                Console.WriteLine("getStringdown!");
            });
            await demo.GetStringAsync();
        }

        public class Demo
        {
            public EventHandler<string> MyEvent;
            public async Task<string> GetStringAsync()
            {
                MyEvent += (e, s) => { GetStringAsync(); };
                await Task.Delay(1000);
                return "模拟获取数据";
            }
        }

    }
}
