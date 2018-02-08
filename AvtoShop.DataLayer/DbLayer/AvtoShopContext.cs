using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AvtoShop.DataLayer.DbLayer
{

    public partial class AvtoShopContext : DbContext
    {
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
				optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AvtoShop;Trusted_Connection=True;App=Test;");

			}
        }
        public virtual DbSet<AutoBody> AutoBodies { get; set; }
        public virtual DbSet<Avto> Avtoes { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<DriveUnit> DriveUnits { get; set; }
        public virtual DbSet<Fuel> Fuels { get; set; }
        public virtual DbSet<KPP> KPPs { get; set; }
        public virtual DbSet<ModelAvto> ModelAvtoes { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Avto>()
            //    .Property(e => e.Price)
            //    .HasPrecision(19, 4);
        }
    }
}
