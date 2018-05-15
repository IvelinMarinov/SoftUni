using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext()
        {
        }

        public HospitalDbContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Patient>(p =>
            {
                p.Property(pr => pr.FirstName).HasMaxLength(50).IsUnicode();
                p.Property(pr => pr.LastName).HasMaxLength(50).IsUnicode();
                p.Property(pr => pr.Address).HasMaxLength(250).IsUnicode();
                p.Property(pr => pr.Email).HasMaxLength(80);

            });

            builder.Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(v => v.Patient)
                .HasForeignKey(v => v.PatientId);

            builder.Entity<Patient>()
                .HasMany(p => p.Diagnoses)
                .WithOne(d => d.Patient)
                .HasForeignKey(d => d.PatientId);

            builder.Entity<Patient>()
                .HasMany(p => p.Prescriptions)
                .WithOne(pm => pm.Patient)
                .HasForeignKey(pm => pm.PatientId);

            builder.Entity<Visitation>()
                .Property(p => p.Comments)
                .HasMaxLength(250)
                .IsUnicode();

            builder.Entity<Diagnose>(d =>
            {
                d.Property(pr => pr.Name).HasMaxLength(50).IsUnicode();
                d.Property(pr => pr.Comments).HasMaxLength(250).IsUnicode();
            });

            builder.Entity<Medicament>()
                .HasMany(m => m.Prescriptions)
                .WithOne(pm => pm.Medicament)
                .HasForeignKey(pm => pm.MedicamentId);

            builder.Entity<Medicament>()
                .Property(m => m.Name).HasMaxLength(50).IsUnicode();
        }
    }
}
