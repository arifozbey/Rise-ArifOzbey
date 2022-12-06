

using Microsoft.EntityFrameworkCore;
using Model;
using System.Configuration;

namespace Consumer
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql("User ID=root;Password=root;Server=192.168.116.89;Port=5432;Database=risearifozbey;Integrated Security=true;Pooling=true;Timeout=15;");
        }
        //Daha fazla bağımlılık olmaması için sadece model katmanı referans alındı.
        public virtual DbSet<KisiModel> KisiModels { get; set; }
        public virtual DbSet<KisiDetayModel> KisiDetayModels { get; set; }
        public virtual DbSet<RaporModel> RaporModels { get; set; }
    }
}
