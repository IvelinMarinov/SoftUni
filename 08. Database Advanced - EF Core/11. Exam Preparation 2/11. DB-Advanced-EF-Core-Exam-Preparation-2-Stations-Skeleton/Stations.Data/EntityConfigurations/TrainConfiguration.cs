using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.EntityConfigurations
{
    public class TrainConfiguration : IEntityTypeConfiguration<Train>
    {
        public void Configure(EntityTypeBuilder<Train> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasAlternateKey(t => t.TrainNumber);

            builder.Property(t => t.TrainNumber)
                .IsRequired(true)
                .HasMaxLength(10);

            builder.Property(t => t.Type)
                .IsRequired(false);

            builder.HasMany(t => t.TrainSeats)
                .WithOne(ts => ts.Train)
                .HasForeignKey(ts => ts.TrainId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Trips)
                .WithOne(tr => tr.Train)
                .HasForeignKey(tr => tr.TrainId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
