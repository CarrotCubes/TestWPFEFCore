using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Prism.Commands;
using Prism.Mvvm;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using TestWPFEFCore.Entity;
using TestWPFEFCore.Services;

namespace TestWPFEFCore.ViewModels
{
    public class MyUserControl1ViewModel : BindableBase
    {
        private readonly ICarService _carService;

        private readonly ILogger<MyUserControl1ViewModel> _logger;

        public MyUserControl1ViewModel(ICarService carService, ILogger<MyUserControl1ViewModel> logger)
        {
            _carService = carService;
            _logger = logger;
        }

        public DelegateCommand command => new DelegateCommand(async () =>
        {
            CarInfo? sss = await _carService.GetFirstAsync();
            _logger.LogInformation(sss.Vin);

            //var factory = new ConnectionFactory() { HostName = "localhost" };
            //using (var connection = factory.CreateConnection())
            //{
            //    using (var channel = connection.CreateModel())
            //    {
            //        //声明队列操作是幂等的，当队列不存在时，会进行创建。
            //        channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
            //        Console.WriteLine("请输入要发送的消息内容：");
            //        string msg = "TestMsgRabbitmq";
            //        while (!string.IsNullOrEmpty(msg))
            //        {
            //            var body = Encoding.UTF8.GetBytes(msg);
            //            //body是byte类型，使用了一个名为“”的默认交换机
            //            channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);

            //            Console.WriteLine("[x] Sent {0}", msg);
            //        }

            //    }
            //}

            //var factory = new ConnectionFactory() { HostName = "localhost" };
            //using (var connection = factory.CreateConnection())
            //{
            //    using (var channel = connection.CreateModel())
            //    {
            //        channel.QueueDeclare("hello", false, false, false, null);

            //        var consumer = new EventingBasicConsumer(channel);
            //        consumer.Received += (model, args) =>
            //        {
            //            byte[] body = args.Body.ToArray();
            //            var msg = Encoding.UTF8.GetString(body);
            //            //Console.WriteLine(" [x] Received {0}", msg);
            //        };
            //        //第二个参数autoAck为true
            //        channel.BasicConsume("hello", true, consumer);
            //        Console.WriteLine("Press [Enter] to exit");
            //        //Console.ReadKey();
            //    }
            //}

            await Task.Delay(1000000);
        });
    }
}
