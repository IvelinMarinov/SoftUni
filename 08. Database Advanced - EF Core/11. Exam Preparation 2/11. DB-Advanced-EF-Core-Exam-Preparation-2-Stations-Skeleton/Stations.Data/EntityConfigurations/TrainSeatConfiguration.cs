using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.EntityConfigurations
{
    public class TrainSeatConfiguration : IEntityTypeConfiguration<TrainSeat>
    {
        public void Configure(EntityTypeBuilder<TrainSeat> builder)
        {
            builder.HasKey(ts => ts.Id);

            builder.Property(ts => ts.TrainId)
                .IsRequired(true);

            builder.Property(ts => ts.SeatingClassId)
                .IsRequired(true);

            builder.Property(ts => ts.Quantity)
                .IsRequired(true);
        }
    }
}
