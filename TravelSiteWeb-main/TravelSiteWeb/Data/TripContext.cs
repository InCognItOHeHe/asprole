using TravelSiteWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TravelSiteWeb.Data
{
    public class TripContext : IdentityDbContext 
    {
        public TripContext()
        {
        }
        


        public TripContext(DbContextOptions<TripContext> options) : base(options) { }
       

        public DbSet<Clients> Clients { get; set; }
        public DbSet<Destinations> Destinations { get; set; }
        public DbSet<Reservations> Reservations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>().ToTable("Clients");
            modelBuilder.Entity<Destinations>().ToTable("Destinations");
            modelBuilder.Entity<Reservations>().ToTable("Reservations");
            base.OnModelCreating(modelBuilder);
        }


    }
}