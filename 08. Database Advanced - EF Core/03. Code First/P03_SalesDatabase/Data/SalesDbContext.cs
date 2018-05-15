using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext()
        {
        }

        public SalesDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);

                entity.HasMany(c => c.Sales)
                    .WithOne(s => s.Customer)
                    .HasForeignKey(s => s.CustomerId);

                entity.Property(c => c.Name)
                    .HasMaxLength(100)
                    .IsUnicode();

                entity.Property(c => c.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });
            
            builder.Entity<Product>(entity =>
            {
                entity.HasKey(c => c.ProductId);

                entity.HasMany(p => p.Sales)
                    .WithOne(s => s.Product)
                    .HasForeignKey(s => s.ProductId);

                entity.Property(pr => pr.Name)
                    .HasMaxLength(50)
                    .IsUnicode();

                entity.Property(pr => pr.Description)
                    .HasMaxLength(250)
                    .HasDefaultValue("No description");
            });

            builder.Entity<Store>(entity =>
            {
                entity.HasKey(c => c.StoreId);

                entity.HasMany(st => st.Sales)
                    .WithOne(sl => sl.Store)
                    .HasForeignKey(sl => sl.StoreId);

                entity.Property(pr => pr.Name)
                    .HasMaxLength(80)
                    .IsUnicode();
            });

            builder.Entity<Sale>(entity =>
            {
                entity.HasKey(c => c.SaleId);

                entity.Property(pr => pr.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
