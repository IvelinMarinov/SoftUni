using BusTicketsSystem.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusTicketsSystem.Data.Configurations
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(ba => ba.Id);

            builder.HasOne(ba => ba.AccountHolder)
                .WithOne(c => c.BankAccount)
                .HasForeignKey<BankAccount>(ba => ba.AccountHolderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
