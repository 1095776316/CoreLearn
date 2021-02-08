using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutofacPro.CustomConfiguration
{
    public static class QueryStringConfigurationExtensions
    {
        public static IConfigurationBuilder AddQueryStringFile(this IConfigurationBuilder builder)
        {
            return AddQueryStringFile(builder, "hhhh.config");
        }

        public static IConfigurationBuilder AddQueryStringFile(this IConfigurationBuilder builder, string path)
        {
            return builder.Add(new QueryStringConfiguationSource(path));
        }
    }
}
