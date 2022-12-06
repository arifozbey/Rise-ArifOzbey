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
    public class UnitTest2Kisi
    {
       static string conn = "User ID=root;Password=root;Server=192.168.116.89;Port=5432;Database=risearifozbey;Integrated Security=true;Pooling=true;Timeout=15;";

        [Fact]
        public async Task ControllerKisiGet()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql(conn);
            var mock = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            ApplicationDbContext data = mock.Object;

            var controller = new CRUDController(data);

            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var result = controller.Get();

            // Assert
            var viewResult = Assert.IsType<IEnumerable<KisiModel>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<KisiModel>>(
                        viewResult.ToList());
            Assert.NotNull(model);

        }
        [Fact]
        public async Task ControllerKisiPut()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql(conn);
            var mock = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            ApplicationDbContext data = mock.Object;

            var controller = new CRUDController(data);

            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var DemoData = new KisiModel() {Id= new Guid("a493787b-9bdd-45f0-8faa-a6f4cf926f48"), Adi = "arif", Firma = "ozbey", Soyadi = "özbey" };
            var result = controller.Post(DemoData);

            // Assert
            var viewResult = Assert.IsType<ActionResult<KisiModel>>(result);
            Assert.IsType<OkResult>(viewResult);

        }
        [Fact]
        public async Task ControllerKisiPost()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql(conn);
            var mock = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            ApplicationDbContext data = mock.Object;

            var controller = new CRUDController(data);

            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var DemoData = new KisiModel() { Adi="arif",Firma="ozbey",Soyadi="özbey"};
            var result = controller.Post(DemoData);

            // Assert
            var viewResult = Assert.IsType<IEnumerable<KisiModel>>(result);
            Assert.IsType<OkResult>(viewResult);

        }
        [Fact]
        public async Task ControllerKisiDelete()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql(conn);
            var mock = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            ApplicationDbContext data = mock.Object;

            var controller = new CRUDController(data);

            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var result = controller.Delete(new Guid("a493787b-9bdd-45f0-8faa-a6f4cf926f48"));

            // Assert
            var viewResult = Assert.IsType<IEnumerable<KisiModel>>(result);
            Assert.IsType<OkResult>(viewResult);

        }
    }
}


