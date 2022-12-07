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
        static string conn = "User ID=root;Password=root;Server=192.168.144.89;Port=5432;Database=risearifozbey;Integrated Security=true;Pooling=true;Timeout=15;";
        DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;

        [Fact]
        public void CRUDKisiGet()
        {
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseNpgsql(conn);


            var controller = new CRUDController(new ApplicationDbContext(_optionsBuilder.Options));
            var result = controller.Get();

            // Assert
         
            Assert.True((result.Count()>0 ? true : false));

        }
        [Fact]
        public void CRUDKisiPut()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseNpgsql(conn);


            var controller = new CRUDController(new ApplicationDbContext(_optionsBuilder.Options));

            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var DemoData = new KisiModel() { Adi = "arifaaa", Firma = "ozbey", Soyadi = "özbey" };
            var result = controller.Put(new Guid("74e85354-757a-49f0-bdce-84e931acdfcb"), DemoData);

            // Assert
            Assert.IsType<OkResult>(result);

        }
        [Fact]
        public void CRUDKisiPost()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseNpgsql(conn);


            var controller = new CRUDController(new ApplicationDbContext(_optionsBuilder.Options));


            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var DemoData = new KisiModel() { Adi = "arif", Firma = "ozbey", Soyadi = "özbey" };
            var result = controller.Post(DemoData);

            // Assert
            Assert.IsType<OkResult>(result);

        }
        [Fact]
        public void CRUDKisiDelete()
        {
            // Arrange veya IApplicationDbContext kullanýlabilir
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseNpgsql(conn);


            var controller = new CRUDController(new ApplicationDbContext(_optionsBuilder.Options));


            // Act guid iþlemi test için rasgele yapýldý, db ler deki id farklý olucaktýr
            var result = controller.Delete(new Guid("74e85354-757a-49f0-bdce-84e931acdfcb"));

            // Assert
            Assert.IsType<OkResult>(result);

        }
    }
}


