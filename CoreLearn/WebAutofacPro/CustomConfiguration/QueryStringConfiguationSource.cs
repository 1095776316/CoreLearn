using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutofacPro.CustomConfiguration
{
    public class QueryStringConfiguationSource : IConfigurationSource
    {
        public string Path { get; }
        public QueryStringConfiguationSource(string path)
        {
            Path = path;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new QueryStringConfigurationProvider(this);
        }
    }
}
