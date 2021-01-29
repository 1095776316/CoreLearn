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
            builder.RegisterType<TestService>().As<ITestService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
