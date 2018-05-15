using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasKey(t => t.TownId);

            builder.HasMany(tw => tw.Teams)
                .WithOne(tm => tm.Town)
                .HasForeignKey(tm => tm.TownId);

            builder.ToTable("Towns");
        }
    }
}
