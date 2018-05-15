using BusTicketsSystem.Data.Configurations;
using BusTicketsSystem.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BusTicketsSystem.Data
{
    public class BusTicketsContext : DbContext
    {
        public BusTicketsContext()
        {
        }

        public BusTicketsContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BusStation> BusStations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BankAccountConfiguration());
            builder.ApplyConfiguration(new BusStationConfiguration());
            builder.ApplyConfiguration(new CompanyConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new TicketConfiguration());
            builder.ApplyConfiguration(new TownConfiguration());
            builder.ApplyConfiguration(new TripConfiguration());
        }
    }
}
