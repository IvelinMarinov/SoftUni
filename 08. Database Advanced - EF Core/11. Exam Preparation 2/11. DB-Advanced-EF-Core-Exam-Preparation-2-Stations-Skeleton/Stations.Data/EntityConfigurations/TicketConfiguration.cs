using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.EntityConfigurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Price)
                .IsRequired(true);

            builder.Property(t => t.SeatingPlace)
                .HasMaxLength(8)
                .IsRequired(true);

            builder.Property(t => t.TripId)
                .IsRequired(true);

            builder.Property(t => t.CustomerCardId)
                .IsRequired(false);
        }
    }
}
