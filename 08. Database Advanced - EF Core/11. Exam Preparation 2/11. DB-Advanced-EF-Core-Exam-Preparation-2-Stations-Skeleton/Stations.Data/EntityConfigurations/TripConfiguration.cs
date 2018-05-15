using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.EntityConfigurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.OriginStationId)
                .IsRequired(true);

            builder.Property(t => t.DestinationStationId)
                .IsRequired(true);

            builder.Property(t => t.DepartureTime)
                .IsRequired(true);

            builder.Property(t => t.ArrivalTime)
                .IsRequired(true);

            builder.Property(t => t.TrainId)
                .IsRequired(true);
            
            builder.Property(t => t.Status)
                .HasDefaultValue(TripStatus.OnTime);

            builder.Property(t => t.TimeDifference)
                .IsRequired(false);
        }
    }
}
