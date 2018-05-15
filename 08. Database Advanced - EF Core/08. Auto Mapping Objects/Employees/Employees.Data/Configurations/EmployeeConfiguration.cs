using Employees.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.Data
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Salary)
                .IsRequired();

            builder.Property(e => e.Address)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(e => e.Birthday)
                .IsRequired(false);

            builder.HasOne(e => e.Manager)
                .WithMany(m => m.EmployeesManaged)
                .HasForeignKey(e => e.ManagerId);
        }
    }
}
