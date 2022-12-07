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
       static string conn = "User ID=root;Password=root;Server=192.168.144.89;Port=5432;Database=risearifozbey;Integrated Security=true;Pooling=true;Timeout=15;";
        DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;

        [Fact]
        public async Task ControllerRaporGet()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseNpgsql(conn);


            var controller = new RaporController(new ApplicationDbContext(_optionsBuilder.Options));

            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var result = controller.Get();

            // Assert
            var viewResult = Assert.IsType<List<RaporModel>>(result);
            var model = Assert.IsAssignableFrom<List<RaporModel>>(
                        viewResult.ToList());
            Assert.True((model.Count() > 0 ? true : false));

        }
        [Fact]
        public async Task ControllerRaporPut()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseNpgsql(conn);


            var controller = new RaporController(new ApplicationDbContext(_optionsBuilder.Options));


            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var DemoData = new RaporModel() { Id=new Guid("89fb46df-a134-4358-8367-50346d53bf2c"),Dosyapath = "asda", Durumu = 1, Konum = "HDD", TalepTarihi = DateTime.Now };
            var result = controller.Post(DemoData);

            // Assert
            Assert.IsType<OkResult>(result);

        }
        [Fact]
        public async Task ControllerRaporPost()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseNpgsql(conn);


            var controller = new RaporController(new ApplicationDbContext(_optionsBuilder.Options));


            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var DemoData = new RaporModel() { Dosyapath="asda",Durumu=1,Konum="HDD",TalepTarihi=DateTime.Now};
            var result = controller.Post(DemoData);

            // Assert
            Assert.IsType<OkResult>(result);

        }
        [Fact]
        public async Task ControllerRaporDelete()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseNpgsql(conn);


            var controller = new RaporController(new ApplicationDbContext(_optionsBuilder.Options));


            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var result = controller.Delete(new Guid("89fb46df-a134-4358-8367-50346d53bf2c"));

            // Assert
            Assert.IsType<OkResult>(result);

        }
    }
}


