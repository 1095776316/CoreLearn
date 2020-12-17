using System;
using System.Threading.Tasks;

namespace LazyDemo
{
    class Program
    {
        static int _simpleValue = 1;
        static readonly Lazy<Task<int>> MySharedInteger = new Lazy<Task<int>>(async () =>
        {
            await Task.Delay(1000).ConfigureAwait(false);
            return ++_simpleValue;
        });

        async static Task Main(string[] args)
        {
            await UseSharedInteger();
            await UseSharedInteger();
            await UseSharedInteger();
            await UseSharedInteger();
            Console.WriteLine("x");
        }

        async static Task UseSharedInteger()
        {
            int sharedVaule = await MySharedInteger.Value;
            Console.WriteLine(sharedVaule);
        }
    }
}
