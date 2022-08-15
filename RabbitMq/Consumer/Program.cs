using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    class Program
    {

        static void Main(string[] args)
        {
            var context = new SchoolContext();
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
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body;
                    var message =  Encoding.UTF8.GetString(body);
                   Console.WriteLine($" message : " + message);


                };

                channel.BasicConsume(queue: "log_queue",
                                     noAck: true,
                                     consumer: consumer);


                Console.ReadLine();
            }

           
        }
      
    }
}
