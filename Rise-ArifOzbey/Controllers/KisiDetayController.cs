using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Rise_ArifOzbey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rise_ArifOzbey.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class KisiDetayController : ControllerBase
    {
        private readonly IApplicationDbContext _context;
        public KisiDetayController(IApplicationDbContext context)
        {
            _context = context;
        }
        //[HttpGet, ActionName("Get")]
        [HttpGet]
        public IEnumerable<KisiDetayModel> GetAll()
        {
            var data = _context.KisiDetayModels.ToList();
            return data;
        }

        [HttpGet("{kisiid}")]
        public IEnumerable<KisiDetayModel> Get(Guid kisiid)
        {
            var data = _context.KisiDetayModels.Where(x=>x.KisiID==kisiid);
            return data;
        }

        [HttpPost("{kisiid}")]
        public IActionResult Post(Guid kisiid, [FromBody] KisiDetayModel obj)
        {
            var data = _context.KisiDetayModels.Add(obj);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] KisiDetayModel obj)
        {
            var databul = _context.KisiDetayModels.SingleOrDefault(x => x.Id == id);
            databul.Email = obj.Email;
            databul.Icerik = obj.Icerik;
            databul.Konum = obj.Konum;
            databul.TelefonNo = obj.TelefonNo;
            _context.KisiDetayModels.Update(databul);
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var data = _context.KisiDetayModels.Where(a => a.Id == id).FirstOrDefault();
            _context.KisiDetayModels.Remove(data);
            _context.SaveChanges();
            return Ok();

        }

    }
}
