using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHangfirePro
{
    public interface IBackGourdJob
    {
        Task ExecuteAsync();
    }

    public class TestJob : IBackGourdJob
    {
        private readonly IBackgroundJobClient _client;
        public TestJob(IBackgroundJobClient client)
        {
            _client = client;
        }
        public async Task ExecuteAsync()
        {
            Store store = new Store();
            RecurringJob.AddOrUpdate(() => SendMsg(store.models), Cron.Minutely);
            await Task.CompletedTask;
        }

        public void SendMsg(List<Model> models)
        {
            models.ForEach(item=> {
                Msg.Send(item);
            });
        }
    }

    public class Msg
    {
        public static bool Send(Model model)
        {
            Task.Delay(1000);
            model.IsSend = true;
            return true;
        }
    }
    public class Store
    {
        public List<Model> models = new List<Model>();

        public Store()
        {
            models.Add(new Model { Id = 1, Name = "张三", IsSend = false, Title = "天机国际", Context = "尊敬的用户张三，你的手机已经欠费一亿元，请及时缴费。否则将会被击毙" });

            models.Add(new Model { Id = 2, Name = "李四", IsSend = false, Title = "天机国际", Context = "尊敬的用户李四，你的手机已经欠费十亿元，请及时缴费。否则将会被击毙" });

            models.Add(new Model { Id = 3, Name = "王五", IsSend = false, Title = "天机国际", Context = "尊敬的用户王五，你的手机已经欠费二十八亿元，请及时缴费。否则将会被击毙" });

            models.Add(new Model { Id = 4, Name = "刘丹", IsSend = false, Title = "天机国际", Context = "尊敬的用户刘丹，你的手机已经欠费一七亿元，请及时缴费。否则将会被击毙" });

            models.Add(new Model { Id = 5, Name = "齐秦", IsSend = false, Title = "天机国际", Context = "尊敬的用户齐秦，你的手机已经欠费一百亿元，请及时缴费。否则将会被击毙" });
        }
    }

    public class Model
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Context { get; set; }

        public bool IsSend { get; set; }
    }
}
