using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(p => p.PositionId);

            builder.HasMany(ps => ps.Players)
                .WithOne(pl => pl.Position)
                .HasForeignKey(pl => pl.PositionId);

            builder.ToTable("Positions");
        }
    }
}
