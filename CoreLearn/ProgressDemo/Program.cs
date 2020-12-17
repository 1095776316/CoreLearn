using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace ProgressDemo
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var result= await Get();
            Console.WriteLine(result);
            Console.ReadKey();
            //var timer = new System.Timers.Timer(interval: 1000) { Enabled = true };
            //Action action = () => Console.WriteLine("hello");
            //IObservable<EventPattern<object>> ticks =
            //    Observable.FromEventPattern(action, nameof(action));

            //ticks.Subscribe(data => Console.WriteLine("OnNext: "));
            //Console.WriteLine("OnNext: ");
            Console.ReadKey();

            //var s = GetValues();
            // foreach (var i in s)
            //{
            //    Console.WriteLine(i);
            //}
            //var progress = new Progress<double>();
            //progress.ProgressChanged += (sender, args) =>
            //{
            //    Console.WriteLine(args);
            //};
            //await MyMethodAsync(progress);
            //Console.ReadKey();
        }


        static Task<string> Get()
        {
            WebClient client = new WebClient();

            var tcs = new TaskCompletionSource<string>();
            DownloadStringCompletedEventHandler handler = null;
            handler = (_, e) =>
            {
                client.DownloadStringCompleted -= handler;
                if (e.Cancelled)
                    tcs.TrySetCanceled();
                else if (e.Error != null)
                    tcs.TrySetException(e.Error);
                else
                    tcs.TrySetResult(e.Result);
            };
            client.DownloadStringCompleted += handler;
            client.DownloadStringAsync(new Uri("http://www.baidu.com"));
            return tcs.Task;
        }
        async static IAsyncEnumerable<int> GetValuesAsync()
        {
            await Task.Delay(1000); // 异步处理
            yield return 10;
            await Task.Delay(1000); // 更多异步处理
            yield return 13;
        }
        public static IEnumerable<int> GetValues()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
        async static Task MyMethodAsync(IProgress<double> progress = null)
        {
            int i = 10;
            bool done = false;
            while (!done)
            {
                i--;
                await Task.Delay(1000);
                progress?.Report(i);
                if (i == 0)
                {
                    done = true;
                }
            }
        }
    }
}
