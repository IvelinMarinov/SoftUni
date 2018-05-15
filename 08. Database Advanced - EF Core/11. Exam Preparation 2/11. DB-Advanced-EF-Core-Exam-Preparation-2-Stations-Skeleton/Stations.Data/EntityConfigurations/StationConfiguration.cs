
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.EntityConfigurations
{
    public class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasAlternateKey(s => s.Name);

            builder.Property(s => s.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(s => s.Town)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.HasMany(s => s.TripsFrom)
                .WithOne(tf => tf.OriginStation)
                .HasForeignKey(tf => tf.OriginStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.TripsTo)
                .WithOne(tt => tt.DestinationStation)
                .HasForeignKey(tt => tt.DestinationStationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
