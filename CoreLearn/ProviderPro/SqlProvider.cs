using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;

namespace ProviderPro
{
    public class SqlProvider : MessageProvider
    {
        private string _conStr;


        public override List<MessageModel> Get()
        {
            Console.WriteLine("medthod:sql_get");
            return new List<MessageModel>();
        }

        public override bool Insert(MessageModel model)
        {
            Console.WriteLine("medthod:sql_insert");
            return true;
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);

            string temp = config["connectionString"];
            _conStr = ConfigurationManager.ConnectionStrings[temp].ConnectionString;
        }
    }
}
