using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Rise_ArifOzbey.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Rise_ArifOzbey.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var list = new List<KisiDetayModel>();
            var model = new KisiDetayModel()
            {
               Email="arifozbey@gmail.com",Icerik="Test",KisiID=Guid.NewGuid(),Konum="Ankara",TelefonNo="05558707802"
            };
            list.Add(model);
            list.Add(model);
            list.Add(model);
            IEnumerable<KisiDetayModel> responsenew = list;

            return View(responsenew);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
