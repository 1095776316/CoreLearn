using System;

namespace ProviderPro2
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageContext message = new MessageContext(MessagePlatformEnum.Mini, "con");
            message.Send(new MsmModel() { Id = 1000, Message = "hwlloe！！！", Age = 200 });
            Console.ReadKey();
        }

        public class MsmModel : MessageModel
        {
            public int Age;
        }
    }
}
