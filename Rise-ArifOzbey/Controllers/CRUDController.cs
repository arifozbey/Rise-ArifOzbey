﻿using Microsoft.AspNetCore.Mvc;
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

    public class CRUDController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CRUDController(ApplicationDbContext context)
        {
            _context = context;
        }
        //[HttpGet, ActionName("Get")]

        [HttpGet]
        public IEnumerable<KisiDetayModels> Get()
        {
            var data = _context.KisiModels.ToList();
            return data;
        }

        [HttpPost]
        public IActionResult Post([FromBody] KisiDetayModels obj)
        {
            var data = _context.KisiModels.Add(obj);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] KisiDetayModels obj)
        {
            var databul = _context.KisiModels.SingleOrDefault(x => x.Id == id);
            databul.Adi = obj.Adi;
            databul.Soyadi = obj.Soyadi;
            databul.Firma = obj.Firma;
            _context.Update(databul);
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var data = _context.KisiModels.Where(a => a.Id == id).FirstOrDefault();
            _context.KisiModels.Remove(data);
            _context.SaveChanges();
            return Ok();

        }

    }
}
