using System;
using System.Collections.Generic;
using System.Text;

namespace ProviderPro2
{
    public abstract class ProviderBase
    {
        public abstract bool Send(MessageModel model);
    }
}
