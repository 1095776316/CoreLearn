using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutofacPro.CustomConfiguration
{
    public class QueryStringConfigurationProvider : ConfigurationProvider
    {
        public QueryStringConfiguationSource Source { get; }
        public QueryStringConfigurationProvider(QueryStringConfiguationSource soucre)
        {
            Source = soucre;
        }

        public override void Load()
        {
            string queryString = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, Source.Path));
            string[] arrays = queryString.Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries); // & 号分隔

            foreach (var item in arrays)
            {
                string[] temps = item.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);  // = 号分隔
                if (temps.Length != 2) continue;

                Data.Add(temps[0], temps[1]);
            }
        }
    }
}
