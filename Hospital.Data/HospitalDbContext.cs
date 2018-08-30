namespace Hospital.Data
{
    using System;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class HospitalDbContext : IdentityDbContext<User>
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Diagnosis> Diagnoses { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<PatientMedicine> PatientMedicine { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<PatientMedicine>()
                .HasKey(pm => new { pm.PatientId, pm.MedicineId });

            builder
                .Entity<PatientMedicine>()
                .HasOne(pm => pm.Medicine)
                .WithMany(m => m.Patients)
                .HasForeignKey(pm => pm.MedicineId);

            builder
                .Entity<PatientMedicine>()
                .HasOne(pm => pm.Patient)
                .WithMany(p => p.Medicines)
                .HasForeignKey(pm => pm.PatientId);

            builder
                .Entity<Patient>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.Patients)
                .HasForeignKey(p => p.DoctorId);

            builder
                .Entity<Patient>()
                .HasOne(p => p.Diagnosis)
                .WithMany(d => d.Patients)
                .HasForeignKey(p => p.DiagnosisId);

            builder
                .Entity<Medicine>()
                .HasOne(m => m.Supplier)
                .WithMany(s => s.Medicines)
                .HasForeignKey(m => m.SupplierId);

            base.OnModelCreating(builder);
        }
    }
}
