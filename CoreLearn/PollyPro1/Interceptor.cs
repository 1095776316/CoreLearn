using Castle.DynamicProxy;
using Polly;
using System;
using System.Collections.Generic;
using System.Text;

namespace PollyPro1
{
    public class Interceptor : StandardInterceptor
    {
        protected override void PreProceed(IInvocation invocation)
        {
            base.PreProceed(invocation);
        }
        protected override void PerformProceed(IInvocation invocation)
        {
            ISyncPolicy policy = Policy.Handle<ArgumentException>().Fallback(() =>
            {
                Console.WriteLine("参数错误，直接捕捉起来干掉");
            });
            policy.Execute(() =>
            {
                base.PerformProceed(invocation);
            });
        }

        protected override void PostProceed(IInvocation invocation)
        {
            base.PostProceed(invocation);
        }
    }
}
