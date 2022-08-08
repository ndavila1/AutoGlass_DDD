using DDD.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.ProductId).IsRequired().HasColumnName("id").ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state");

                entity.Property(e => e.ManufacturingDate)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasColumnName("manufacturing_date");

                entity.Property(e => e.ValidityDate)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasColumnName("validity_date");

            });

            modelBuilder.Entity<Product>().OwnsOne(o => o.Provider, conf =>
            {

                conf.Property(x => x.ProviderId).HasColumnName("provider_id");
                conf.Property(x => x.Description).HasColumnName("descripcion_provider");
                conf.Property(x => x.PhoneNumber).HasColumnName("phone_number_provider");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
