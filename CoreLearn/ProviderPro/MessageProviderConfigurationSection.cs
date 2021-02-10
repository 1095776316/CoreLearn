﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ProviderPro
{
    public class MessageProviderConfigurationSection : ConfigurationSection
    {
        private readonly ConfigurationProperty _defaultProvider;
        private readonly ConfigurationProperty _providers;
        private readonly ConfigurationPropertyCollection _properties;

        public MessageProviderConfigurationSection()
        {
            _defaultProvider = new ConfigurationProperty("defaultProvider", typeof(string), null);
            _providers = new ConfigurationProperty("providers", typeof(ProviderSettingsCollection), null);
            _properties = new ConfigurationPropertyCollection();

            _properties.Add(_providers);
            _properties.Add(_defaultProvider);
        }

        [ConfigurationProperty("defaultProvider")]
        public string DefaultProvider
        {
            get { return (string)base[_defaultProvider]; }
            set { base[_defaultProvider] = value; }
        }

        [ConfigurationProperty("providers", DefaultValue = "SqlMessageProvider")]
        [StringValidator(MinLength = 1)]
        public ProviderSettingsCollection Providers
        {
            get { return (ProviderSettingsCollection)base[_providers]; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }
    }
}
