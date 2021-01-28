using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebAutofacPro
{
    public class ConfigureAutofac : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LogInterceptor>();
            builder.RegisterType<MyInterceptor>(); 
            builder.RegisterType<TestService>().As<ITestService>().AsImplementedInterfaces().InstancePerLifetimeScope().EnableInterfaceInterceptors().InterceptedBy(typeof(LogInterceptor));
            base.Load(builder);
        }
    }
}
