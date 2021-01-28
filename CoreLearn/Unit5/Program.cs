using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Unit5
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Test1();
            Console.ReadKey();
        }

        static async Task Test1()
        {
            var multiplyBlock = new TransformBlock<int, int>(item =>
            {
                var d = item * 2;
                Console.WriteLine(d);
                return d;
            });
            var subtractBlock = new TransformBlock<int, int>(item =>
            {
                var d = item - 2;
                Console.WriteLine(d);
                return d;
            });
            multiplyBlock.LinkTo(subtractBlock);
            multiplyBlock.Post(4);
            multiplyBlock.Post(9);
            await Task.Delay(200);
            // multiplyBlock.Complete();
            // await subtractBlock.Completion;
        }
    }
}
