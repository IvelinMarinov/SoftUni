﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configurations
{
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
                builder.HasKey(h => h.HomeworkId);

                builder.ToTable("HomeworkSubmissions");

                builder.Property(h => h.Content)
                .IsUnicode(false);
        }
    }
}
