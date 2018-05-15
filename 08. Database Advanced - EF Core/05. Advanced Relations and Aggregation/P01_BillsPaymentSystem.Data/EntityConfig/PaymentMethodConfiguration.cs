using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(pm => pm.Id);

            builder.HasOne(pm => pm.BankAccount)
                .WithOne(ba => ba.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.BankAccountId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(pm => pm.CreditCard)
                .WithOne(ba => ba.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.CreditCardId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(pm => pm.Type)
                .IsRequired();

            builder.Property(pm => pm.UserId)
                .IsRequired();

            builder.Property(pm => pm.BankAccountId)
                .IsRequired(false);

            builder.Property(pm => pm.CreditCardId)
                .IsRequired(false);

            builder.HasIndex(pm => new {pm.UserId, pm.BankAccountId, pm.CreditCardId})
                .IsUnique();
        }
    }
}
