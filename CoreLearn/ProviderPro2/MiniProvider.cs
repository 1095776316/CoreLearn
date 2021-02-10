using Newtonsoft.Json;
using System;

namespace ProviderPro2
{
    public class MiniProvider : ProviderBase
    {
        private string _url = "http://minichat.com?token={0}";
        private string _token;

        public MiniProvider(string token)
        {
            _token = token;
        }

        public override bool Send(MessageModel model)
        {
            var msg = JsonConvert.SerializeObject(model);
            var url = string.Format(_url, _token);
            Console.WriteLine($"-------------------------");
            Console.WriteLine($"发送小程序消息：{url}");
            Console.WriteLine($"消息内容：{msg}");
            Console.WriteLine($"-------------------------");
            return true;
        }
    }
}
