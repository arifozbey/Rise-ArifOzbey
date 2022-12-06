using ClosedXML.Excel;
using Consumer;
using Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsumerRabbitMQ
{
    class Program
    {
        private static ApplicationDbContext context = new ApplicationDbContext();

        static void Main(string[] args)
        {
            //var context = new ApplicationDbContext();
            #region Burası Test Amaçlı
            var sonuc = context.RaporModels.AsQueryable().Where(x => x.TalepTarihi < DateTime.Now.AddDays(1)).ToList();
            foreach (var item in sonuc)
            {
                Console.WriteLine($" message işlem tarihi: " + item.TalepTarihi + ": " + item.Konum + " " + item.Durumu);

            }
            #endregion

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {

                channel.QueueDeclare(queue: "log_queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var konum = Encoding.UTF8.GetString(body);
                    Console.WriteLine($" gelen konum : " + konum);
                    string kelime = konum.Replace("\"", "");
                    var rabbitdata = kelime.Split(",");
                    Helper.raporolustur(rabbitdata[0], rabbitdata[1]);

                };

                channel.BasicConsume(queue: "log_queue",
                                     noAck: true,
                                     consumer: consumer);


                Console.ReadLine();
            }


        }
      
    }
}
