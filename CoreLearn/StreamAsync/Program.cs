using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace StreamAsync
{
    class Program
    {
        async static Task Main(string[] args)
        {

            IAsyncEnumerable<int> values = SlowRange();

            await foreach (int result in values)
            {
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }

        async static IAsyncEnumerable<int> SlowRange()
        {
            for (int i = 0; i != 10; i++)
            {
                await Task.Delay(i * 1000);
                yield return i;
            }
        }





        static async IAsyncEnumerable<int> GetValueAsync()
        {
            await Task.Delay(1000);
            yield return 10;
            await Task.Delay(1000);
            yield return 20;
        }

        static async IAsyncEnumerable<string> GetValueAsync(HttpClient httpClient)
        {
            int offset = 0;
            const int limit = 10;
            while (true)
            {
                string result = await httpClient.GetStringAsync("http://www.baidu.com");
                string[] values = result.Split('\n');
                foreach (string value in values)
                    yield return value;

                if (values.Length != limit)
                    break;

                offset += limit;
            }
        }
    }
}
