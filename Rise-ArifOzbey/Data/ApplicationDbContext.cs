using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rise_ArifOzbey.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<KisiModel> KisiModels { get; set; }
        public virtual DbSet<KisiDetayModel> KisiDetayModels { get; set; }
        public virtual DbSet<RaporModel> RaporModels { get; set; }
    }
}
