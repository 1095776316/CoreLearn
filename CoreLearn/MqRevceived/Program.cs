using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MqRevceived
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Test>()
            {
                new Test(){
                Name="张三"
                },
                new Test(){
                Name="李四"
                },
                 new Test(){
                Name="王五"
                },
            };

            list.ForEach(item=>Inesert(item));
        }

        private static void Inesert(Test item)
        {
           
        }

        public class Test
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        //#region 1
        //static void Main(string[] args)
        //{
        //    var factory = new ConnectionFactory();
        //    factory.HostName = "212.64.14.25";
        //    factory.UserName = "remote";
        //    factory.Password = "remote";

        //    using var connetcion = factory.CreateConnection();
        //    using var channel = connetcion.CreateModel();
        //    channel.QueueDeclare("KibaQueue", false, false, false, null);
        //    var consumer = new EventingBasicConsumer(channel);
        //    channel.BasicConsume("KibaQueue", true, consumer);
        //    consumer.Received += (model, ea) =>
        //    {
        //        var body = ea.Body.ToArray();
        //        var message = Encoding.UTF8.GetString(body);
        //        Console.WriteLine($"recvied:{message}");
        //    };
        //} 
        //#endregion
    }
}
