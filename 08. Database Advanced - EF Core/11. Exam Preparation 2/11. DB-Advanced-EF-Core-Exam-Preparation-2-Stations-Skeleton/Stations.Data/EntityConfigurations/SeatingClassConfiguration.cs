using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.EntityConfigurations
{
    public class SeatingClassConfiguration : IEntityTypeConfiguration<SeatingClass>
    {
        public void Configure(EntityTypeBuilder<SeatingClass> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.HasAlternateKey(sc => new { sc.Name, sc.Abbreviation });

            builder.Property(sc => sc.Name)
                .IsRequired(true)
                .HasMaxLength(30);

            builder.Property(sc => sc.Abbreviation)
                .HasColumnType("CHAR(2)")
                .IsRequired(true);
        }
    }
}
