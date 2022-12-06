using RabbitMQ.Client.Events;
using System;
using System.Threading.Tasks;
using Xunit;
using RabbitMQ.Client;
using System.Text;
using ConsumerRabbitMQ;

namespace UnitTest
{
    public class RabbitMQ
    {
        [Fact]
        public void ConsumerAPPRabbit()
        {

            // ARRANGE
            var cts = "Deneme";
            var fake = "Demo";

            // ACT
            var Response = RabbitMQ.Calistir();


            // ASSERT
            Assert.True(Response);
        }

        private static bool Calistir()
        {

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
                return true;
            }
        }
    }
}


