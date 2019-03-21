using System;
using Microsoft.EntityFrameworkCore;

namespace batyaWeb.Models
{
    public class SiteContext : DbContext
    {
        public DbSet<Site> Sites { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite ("Data Source=SitesDB.db");
        }
    }
}
