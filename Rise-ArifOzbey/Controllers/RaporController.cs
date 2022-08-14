using Microsoft.AspNetCore.Mvc;
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
    public class RaporController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RaporController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public IEnumerable<KisiDetayModels> Get(int id)
        {
            var data = _context.KisiModels.ToList();
            return data;
        }
    }
}
