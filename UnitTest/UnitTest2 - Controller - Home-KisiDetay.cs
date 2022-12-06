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

    public class UnitTest2
    {
        static string conn = "User ID=root;Password=root;Server=192.168.116.89;Port=5432;Database=risearifozbey;Integrated Security=true;Pooling=true;Timeout=15;";

        [Fact]
        public async Task ControllerIndex()
        {
            // Arrange
            var mock = new Mock<ILogger<HomeController>>();
            ILogger<HomeController> logger = mock.Object;

            //or use this short equivalent 
            logger = Mock.Of<ILogger<HomeController>>();

            var controller = new HomeController(logger);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<KisiDetayModel>>(
                viewResult.Model);
            Assert.Equal(3, model.Count());

        }
        [Fact]
        public async Task ControllerPrivacy()
        {
            // Arrange
            var mock = new Mock<ILogger<HomeController>>();
            ILogger<HomeController> logger = mock.Object;

            //or use this short equivalent 
            logger = Mock.Of<ILogger<HomeController>>();

            var controller = new HomeController(logger);

            // Act
            var result = controller.Privacy();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = viewResult.Model == null ? 0 : 1;
            Assert.Equal(0, model);

        }
        [Fact]
        public async Task ControllerKisiDetayGet()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql(conn);
            var mock = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            ApplicationDbContext data = mock.Object;

            var controller = new KisiDetayController(data);

            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var result = controller.Get(new Guid("a493787b-9bdd-45f0-8faa-a6f4cf926f48"));

            // Assert
            var viewResult = Assert.IsType<IEnumerable<KisiDetayModel>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<KisiDetayModel>>(
                        viewResult.ToList());
            Assert.Equal(1, model.Count());

        }
        [Fact]
        public async Task ControllerKisiDetayPut()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql(conn);
            var mock = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            ApplicationDbContext data = mock.Object;

            var controller = new KisiDetayController(data);

            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var DemoData = new KisiDetayModel();
            var result = controller.Put(new Guid("a493787b-9bdd-45f0-8faa-a6f4cf926f48"), DemoData);

            // Assert
            var viewResult = Assert.IsType<IEnumerable<KisiDetayModel>>(result);
            Assert.IsType<OkResult>(viewResult);

        }

        [Fact]
        public async Task ControllerKisiDetayDelete()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql(conn);
            var mock = new Mock<ApplicationDbContext>(optionsBuilder.Options);
            ApplicationDbContext data = mock.Object;

            var controller = new KisiDetayController(data);

            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var DemoData = new KisiDetayModel();
            var result = controller.Delete(new Guid("a493787b-9bdd-45f0-8faa-a6f4cf926f48"));

            // Assert
            var viewResult = Assert.IsType<IEnumerable<KisiDetayModel>>(result);
            Assert.IsType<OkResult>(viewResult);

        }
    }
}


