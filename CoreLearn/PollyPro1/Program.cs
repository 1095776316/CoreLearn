using Castle.DynamicProxy;
using Polly;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PollyPro1
{
    class Program
    {
        static void Main(string[] args)
        {

            ProxyGenerator generator = new ProxyGenerator(); // 实例化代理生成器
            Interceptor interceptor = new Interceptor(); //实例化拦截器
            Test test = generator.CreateClassProxy<Test>(interceptor);
            test.Say();
            //ISyncPolicy policy = Policy.Handle<ArgumentException>().Fallback(() =>
            //{
            //    Console.WriteLine("Error");
            //});

            //policy.Execute(() =>
            //{
            //    Console.WriteLine("start");
            //    throw new ArgumentException("error....");
            //});
        }
    }
}
