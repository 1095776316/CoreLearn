using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Text;

namespace ProviderPro
{
    public  class MessageProviderCollection:ProviderCollection
    {
        public override void Add(ProviderBase provider)
        {
            base.Add(provider);
        }
    }
}
