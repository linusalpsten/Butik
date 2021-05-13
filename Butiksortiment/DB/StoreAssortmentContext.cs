using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAssortment.DB
{
    public class StoreAssortmentContext : DbContext
    {
        public DbSet<StoreAssortmentItem> StoreAssortmentItems { get; set; }

        public StoreAssortmentContext(DbContextOptions<StoreAssortmentContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding
            modelBuilder.Entity<StoreAssortmentItem>().HasData(new StoreAssortmentItem
            {
                Id = Guid.NewGuid(),
                Name = "Kycklingspett",
                Description = "Delikata frysta kycklingspett marinerade i chilisås",
                Price = 100
            });
            modelBuilder.Entity<StoreAssortmentItem>().HasData(new StoreAssortmentItem
            {
                Id = Guid.NewGuid(),
                Name = "Lasagne",
                Description = "God lasagne",
                Price = 70
            });
            modelBuilder.Entity<StoreAssortmentItem>().HasData(new StoreAssortmentItem
            {
                Id = Guid.NewGuid(),
                Name = "Glasstårta",
                Description = "Vacker tårta med tre lager glass på en god nötbotten",
                Price = 150
            });
            modelBuilder.Entity<StoreAssortmentItem>().HasData(new StoreAssortmentItem
            {
                Id = Guid.NewGuid(),
                Name = "Äppelpaj",
                Description = "Smulig äppelpaj som är magiskt god",
                Price = 140
            });
            modelBuilder.Entity<StoreAssortmentItem>().HasData(new StoreAssortmentItem
            {
                Id = Guid.NewGuid(),
                Name = "Pyttipanna",
                Description = "Finskuren pyttipanna",
                Price = 90
            });
        }
    }
}
