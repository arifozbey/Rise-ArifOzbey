using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using Moq;
using Rise_ArifOzbey.Controllers;
using Rise_ArifOzbey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class UnitTest2Rapor
    {
       static string conn = "User ID=root;Password=root;Server=192.168.116.89;Port=5432;Database=risearifozbey;Integrated Security=true;Pooling=true;Timeout=15;";

        [Fact]
        public async Task ControllerRaporGet()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql(conn);
            var mock = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            ApplicationDbContext data = mock.Object;

            var controller = new RaporController(data);

            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var result = controller.Get(new Guid("a493787b-9bdd-45f0-8faa-a6f4cf926f48"));

            // Assert
            var viewResult = Assert.IsType<IEnumerable<RaporModel>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<RaporModel>>(
                        viewResult.ToList());
            Assert.Equal(1, model.Count());

        }
        [Fact]
        public async Task ControllerRaporPut()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql(conn);
            var mock = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            ApplicationDbContext data = mock.Object;

            var controller = new RaporController(data);

            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var DemoData = new RaporModel() { Id=new Guid("a493787b-9bdd-45f0-8faa-a6f4cf926f48"),Dosyapath = "asda", Durumu = 1, Konum = "HDD", TalepTarihi = DateTime.Now };
            var result = controller.Post(DemoData);

            // Assert
            var viewResult = Assert.IsType<ActionResult<RaporModel>>(result);
            Assert.IsType<OkResult>(viewResult);

        }
        [Fact]
        public async Task ControllerRaporPost()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql(conn);
            var mock = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            ApplicationDbContext data = mock.Object;

            var controller = new RaporController(data);

            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var DemoData = new RaporModel() { Dosyapath="asda",Durumu=1,Konum="HDD",TalepTarihi=DateTime.Now};
            var result = controller.Post(DemoData);

            // Assert
            var viewResult = Assert.IsType<IEnumerable<RaporModel>>(result);
            Assert.IsType<OkResult>(viewResult);

        }
        [Fact]
        public async Task ControllerRaporDelete()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql(conn);
            var mock = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            ApplicationDbContext data = mock.Object;

            var controller = new RaporController(data);

            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var result = controller.Delete(new Guid("a493787b-9bdd-45f0-8faa-a6f4cf926f48"));

            // Assert
            var viewResult = Assert.IsType<IEnumerable<RaporModel>>(result);
            Assert.IsType<OkResult>(viewResult);

        }
    }
}


