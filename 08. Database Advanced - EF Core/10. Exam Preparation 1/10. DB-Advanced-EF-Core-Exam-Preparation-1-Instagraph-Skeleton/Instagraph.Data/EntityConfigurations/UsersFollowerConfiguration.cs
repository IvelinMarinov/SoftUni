using Instagraph.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instagraph.Data.EntityConfigurations
{
    public class UsersFollowerConfiguration : IEntityTypeConfiguration<UserFollower>
    {
        public void Configure(EntityTypeBuilder<UserFollower> builder)
        {
            builder.HasKey(uf => new {uf.UserId, uf.FollowerId});

            builder.Property(uf => uf.UserId)
                .IsRequired();

            builder.Property(uf => uf.FollowerId)
                .IsRequired();
        }
    }
}
