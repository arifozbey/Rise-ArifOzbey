using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rise_ArifOzbey.Data
{
    public interface IApplicationDbContext
    {
        DbSet<KisiModel> KisiModels { get; set; }
        DbSet<KisiDetayModel> KisiDetayModels { get; set; }
        DbSet<RaporModel> RaporModels { get; set; }
        int SaveChanges();
    }

}
