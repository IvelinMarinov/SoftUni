using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            builder.Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(s => s.PhoneNumber)
                .HasColumnType("CHAR(10)")
                .IsRequired(false)
                .IsUnicode(false);

            builder.Property(s => s.Birthday)
                .HasColumnType("DATETIME")
                .IsRequired(false);

            builder.Property(s => s.RegisteredOn)
                .HasColumnType("DATETIME");

            builder.HasMany(s => s.HomeworkSubmissisons)
                .WithOne(h => h.Student)
                .HasForeignKey(h => h.StudentId);

            builder.HasMany(s => s.CourseEnrollments)
                .WithOne(sc => sc.Student)
                .HasForeignKey(sc => sc.StudentId);
        }
    }
}
