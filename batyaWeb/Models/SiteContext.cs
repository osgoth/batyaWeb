using System;
using Microsoft.EntityFrameworkCore;

namespace batyaWeb.Models
{
    public class SiteContext : DbContext
    {
        public DbSet<Site> Sites { get; set; }
        public SiteContext (DbContextOptions<SiteContext> options) : base (options)
        {
            Database.EnsureCreated ();
        }
    }
}
