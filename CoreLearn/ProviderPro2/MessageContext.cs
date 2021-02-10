using System;
using System.Collections.Generic;
using System.Text;

namespace ProviderPro2
{
    public class MessageContext
    {
        private ProviderBase _provider;

        public MessageContext(MessagePlatformEnum @enum, string key)
        {
            Load(@enum, key);
        }

        public bool Send(MessageModel model)
        {
            return _provider.Send(model);
        }

        public void Load(MessagePlatformEnum @enum, string key)
        {
            switch (@enum)
            {
                case MessagePlatformEnum.Mini:
                    _provider = new MiniProvider(Config.Token);
                    break;
                case MessagePlatformEnum.WeChat:
                    _provider = new WechatProvider(Config.Token);
                    break;
            }
        }
    }
}
