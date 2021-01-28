using RabbitMQ.Client;
using System;
using System.Text;

namespace MQSend
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "212.64.14.25",
                UserName = "remote",
                Password = "remote"
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("KibaQueue", false, false, false, null);
            var properties = channel.CreateBasicProperties();
            properties.DeliveryMode = 1;
            string message = "i am kiba518";
            channel.BasicPublish("","KibaQueue",properties,Encoding.UTF8.GetBytes(message));
            Console.WriteLine($"send:{message}");
        }
    }
}
