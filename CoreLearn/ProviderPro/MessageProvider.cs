using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Text;

namespace ProviderPro
{
    public abstract class MessageProvider : ProviderBase
    {
        public abstract bool Insert(MessageModel model);

        public abstract List<MessageModel> Get();
    }
}
