using BusTicketsSystem.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTicketsSystem.Data.Configurations
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasMany(t => t.Customers)
                .WithOne(c => c.HomeTown)
                .HasForeignKey(c => c.HomeTownId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.BusStations)
                .WithOne(bs => bs.Town)
                .HasForeignKey(bs => bs.TownId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
