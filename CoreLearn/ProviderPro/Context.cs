using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ProviderPro
{
    public class Context
    {
        private static bool m_isInitialized = false;
        private static MessageProviderCollection _providers = null;
        private static MessageProvider _provider = null;

        static Context()
        {
            Initialize();
        }

        public static bool Insert(MessageModel model)
        {
            return _provider.Insert(model);
        }

        public static List<MessageModel> Get()
        {
            return _provider.Get();
        }

        private static void Initialize()
        {
            MessageProviderConfigurationSection messageConfig = null;
            // 找到配置文件中“MessageProvider”节点
           // messageConfig = (MessageProviderConfigurationSection)ConfigurationManager.GetSection("MessageProvider");

            //if (messageConfig == null)
               // throw new ConfigurationErrorsException("在配置文件中没找到“MessageProvider”节点");

            _providers = new MessageProviderCollection();

            // 使用System.Web.Configuration.ProvidersHelper类调用每个Provider的Initialize()方法
            // ProvidersHelper.InstantiateProviders(messageConfig.Providers, _providers, typeof(MessageProvider));

            // 所用的Provider为配置中默认的Provider
            _provider = _providers["SqlMessageProvider"] as MessageProvider;

            m_isInitialized = true;
        }
    }
}
