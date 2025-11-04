using Microsoft.EntityFrameworkCore;
using DialysisCRM.API.Models;

namespace DialysisCRM.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedicalInfo> PatientMedicalInfos { get; set; }
        public DbSet<PatientReferral> Referrals { get; set; }
        public DbSet<PatientDocument> PatientDocuments { get; set; }
        public DbSet<CMS107Eligibility> CMS107Eligibilities { get; set; }
        public DbSet<Insurance> Insurances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.MedicalInfo)
                .WithOne(m => m.Patient)
                .HasForeignKey<PatientMedicalInfo>(m => m.PatientId);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Referral)
                .WithOne(r => r.Patient)
                .HasForeignKey<PatientReferral>(r => r.PatientId);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.CMS107)
                .WithOne(c => c.Patient)
                .HasForeignKey<CMS107Eligibility>(c => c.PatientId);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Insurance)
                .WithOne(i => i.Patient)
                .HasForeignKey<Insurance>(i => i.PatientId);

            // One-to-Many: Patient → Documents
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Documents)
                .WithOne(d => d.Patient)
                .HasForeignKey(d => d.PatientId);
        }
    }
}