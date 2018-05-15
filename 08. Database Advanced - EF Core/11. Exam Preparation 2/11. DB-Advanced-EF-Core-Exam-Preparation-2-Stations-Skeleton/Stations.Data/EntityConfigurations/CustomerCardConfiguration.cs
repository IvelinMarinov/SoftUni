using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.EntityConfigurations
{
    public class CustomerCardConfiguration : IEntityTypeConfiguration<CustomerCard>
    {
        public void Configure(EntityTypeBuilder<CustomerCard> builder)
        {
            builder.HasKey(cc => cc.Id);

            builder.Property(cc => cc.Name)
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(cc => cc.Age)
                .IsRequired(false);

            builder.Property(cc => cc.Type)
                .HasDefaultValue(CardType.Normal);

            builder.HasMany(cc => cc.BoughtTickets)
                .WithOne(bt => bt.CustomerCard)
                .HasForeignKey(bt => bt.CustomerCardId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
