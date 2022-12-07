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
        static string conn = "User ID=root;Password=root;Server=192.168.144.89;Port=5432;Database=risearifozbey;Integrated Security=true;Pooling=true;Timeout=15;";
        DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;

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
        public async Task ControllerKisiDetayPost()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseNpgsql(conn);


            var controller = new KisiDetayController(new ApplicationDbContext(_optionsBuilder.Options));

            var data = new KisiDetayModel() { Email="arif@arif.com",Icerik="asd",KisiID=Guid.NewGuid(),Konum="aaaa",TelefonNo="123" };
            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var result = controller.Post(new Guid("dacb22bb-b404-483b-a7e6-854455b37fde"), data);

            // Assert
       
            Assert.IsType<OkResult>(result);

        }

        [Fact]
        public async Task ControllerKisiDetayGet()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseNpgsql(conn);


            var controller = new KisiDetayController(new ApplicationDbContext(_optionsBuilder.Options));



            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var result = controller.Get(new Guid("dacb22bb-b404-483b-a7e6-854455b37fde"));

            // Assert
          
            Assert.Equal(1, result.Count());

        }
        [Fact]
        public async Task ControllerKisiDetayGetAll()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseNpgsql(conn);


            var controller = new KisiDetayController(new ApplicationDbContext(_optionsBuilder.Options));



            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var result = controller.GetAll();

            // Assert

            Assert.True((result.Count() > 0 ? true : false));

        }
        [Fact]
        public async Task ControllerKisiDetayPut()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseNpgsql(conn);


            var controller = new KisiDetayController(new ApplicationDbContext(_optionsBuilder.Options));



            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var data = new KisiDetayModel() { Email = "arif@arif.com", Icerik = "asd", KisiID = Guid.NewGuid(), Konum = "aaaa", TelefonNo = "123" };
            var result = controller.Put(new Guid("dacb22bb-b404-483b-a7e6-854455b37fde"), data);

            // Assert
            Assert.IsType<OkResult>(result);

        }

        [Fact]
        public async Task ControllerKisiDetayDelete()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseNpgsql(conn);


            var controller = new KisiDetayController(new ApplicationDbContext(_optionsBuilder.Options));



            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var DemoData = new KisiDetayModel();
            var result = controller.Delete(new Guid("dacb22bb-b404-483b-a7e6-854455b37fde"));

            // Assert
            Assert.IsType<OkResult>(result);

        }
    }
}


