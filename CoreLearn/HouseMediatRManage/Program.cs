using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HouseMediatRManage
{
    class Program
    {
        public static async Task GetAsync()
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine(id);
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync("http://www.baidu.com");
            int id2 = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine(id2);
            Console.WriteLine(result);
        }

        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddMediatR(typeof(Program).Assembly);
            services.AddScoped<ILogger, Logger>();
            services.AddScoped<IData, Data>();
            var serviceProvider = services.BuildServiceProvider();
            var mdeiator = serviceProvider.GetService<IMediator>();
            int response = await mdeiator.Send(new MyRequestMsg() { MsgType = "好消息" });
            await mdeiator.Publish(new UserAdd() { Name = "三三" });
            Console.WriteLine($"{response}");
            Console.ReadKey();
        }
    }

    public interface IData
    {
        string GetData();
    }

    public class Data : IData
    {
        private readonly ILogger _logger;
        public Data(ILogger logger)
        {
            _logger = logger;
        }
        public string GetData()
        {
            _logger.Info("数据库查询数据");
            return "数据库数据";
        }
    }
    public interface ILogger
    {
        void Info(string message);
    }

    public class Logger : ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine($"info:{message}");
        }
    }

    public class MyRequestHandler : IRequestHandler<MyRequestMsg, int>
    {
        private readonly ILogger _logger;
        private readonly IData _data;
        public MyRequestHandler(ILogger logger, IData data)
        {
            _logger = logger;
            _data = data;
        }
        public Task<int> Handle(MyRequestMsg request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"处理消息：{request.MsgType}");
            Console.WriteLine($"获取数据:{_data.GetData()}");
            _logger.Info(request.MsgType);
            return Task.FromResult(100);
        }
    }

    public class MyRequestMsg : IRequest<int>
    {
        public string MsgType { get; set; }
    }

    public class UserAdd : INotification
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class UserAddMsgHandler : INotificationHandler<UserAdd>
    {
        private readonly ILogger _logger;
        private readonly IData _data;
        public UserAddMsgHandler(ILogger logger, IData data)
        {
            _logger = logger;
            _data = data;
        }

        public Task Handle(UserAdd notification, CancellationToken cancellationToken)
        {
            _logger.Info($"UserAddMsgHandler:{notification.Name}");
            return Task.CompletedTask;
        }
    }

    public class UserAddEmailSendHandler : INotificationHandler<UserAdd>
    {
        private readonly ILogger _logger;
        public UserAddEmailSendHandler(ILogger logger)
        {
            _logger = logger;
        }

        public Task Handle(UserAdd notification, CancellationToken cancellationToken)
        {
            _logger.Info($"UserAddEmailSendHandler:{notification.Name}");
            return Task.CompletedTask;
        }
    }
}
