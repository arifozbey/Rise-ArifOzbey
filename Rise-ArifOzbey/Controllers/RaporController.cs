using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Rise_ArifOzbey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise_ArifOzbey.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaporController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RaporController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<RaporModel> Get()
        {
            var data = _context.RaporModels.ToList();
            return data;
        }

        [HttpPost]
        public IActionResult Post([FromBody] RaporModel data)
        {
            var obj = new RaporModel();
            obj.Konum = data.Konum;
            obj.Durumu = (int)RaporDurum.Hazirlaniyor;
            obj.TalepTarihi = DateTime.Now;
            _context.RaporModels.Add(obj);
            var idbul = _context.SaveChanges();
            var task = Task.Run(async () => await RaabitKuyrugaGonder(obj.Id.ToString(), data.Konum)).Result;

            return Ok();
        }

        //[HttpGet, ActionName("Get")]

        [HttpGet("{raporid}")]
        public IEnumerable<RaporModel> Get(Guid raporid)
        {
            var data = _context.RaporModels.Where(x => x.Id == raporid);
            return data;
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var data = _context.RaporModels.Where(a => a.Id == id).FirstOrDefault();
            _context.RaporModels.Remove(data);
            _context.SaveChanges();
            return Ok();

        }

        /// rabbitmq kuyruğa gönder
        async Task<bool> RaabitKuyrugaGonder(string islemid, string konum)
        {
            var delay = 2000;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "log_queue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);


                    //var log = new LogModel(); istenirse log eklenebilir
                    //log.Id = i;
                    //log.Time = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss");
                    //log.Message = string.Format("Log Message {0}", i);

                    //var kuyrukdata = JsonConvert.SerializeObject(log); istenirse json eklenebilir

                    var kuyrukdata = islemid + "," + konum;
                    var body = Encoding.UTF8.GetBytes(kuyrukdata);

                    channel.BasicPublish(exchange: "",
                                     routingKey: "log_queue",
                                     basicProperties: null,
                                     body: body);

                    Console.WriteLine("{0} has been sent to the queue.", kuyrukdata);
                    System.Threading.Thread.Sleep(delay);

                }
            }
            return true;

        }

    }
}
