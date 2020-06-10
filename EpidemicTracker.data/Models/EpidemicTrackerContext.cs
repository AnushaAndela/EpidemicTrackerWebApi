using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EpidemicTracker.data.Models
{
    public class EpidemicTrackerContext : DbContext
    {
        public EpidemicTrackerContext(DbContextOptions<EpidemicTrackerContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Disease> Disease { get; set; }
        public virtual DbSet<DiseaseType> DiseaseType { get; set; }
        public virtual DbSet<Hospital> Hospital { get; set; }
        public virtual DbSet<Occupation> Occupation { get; set; }
        public virtual DbSet<OccupationType> OccupationType { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Treatment> Treatment { get; set; }
        public virtual DbSet<Login> Login { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=EpidemicTrackerDB;Integrated Security=True");
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.AddressId);
                entity.HasIndex(e => e.PatientId);

                entity.Property(e => e.AddressType).IsRequired();

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.Hno).IsRequired();

                entity.Property(e => e.State).IsRequired();

                entity.Property(e => e.Street).IsRequired();

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.PatientId);
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.HasKey(e => e.DiseaseId);
                entity.HasIndex(e => e.DiseaseTypeId);

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.DiseaseType)
                    .WithMany(p => p.Disease)
                    .HasForeignKey(d => d.DiseaseTypeId);
            });

            modelBuilder.Entity<DiseaseType>(entity =>
            {
                entity.HasKey(e => e.DiseaseTypeId);
                entity.Property(e => e.TypeOfDisease).IsRequired();
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.HasKey(e => e.HospitalId);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.HasKey(e => e.OccupationId);
                entity.HasIndex(e => e.PatientId);

                entity.Property(e => e.Area).IsRequired();

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.State).IsRequired();

                entity.Property(e => e.StreetNo).IsRequired();

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Occupation)
                    .HasForeignKey(d => d.PatientId);
            });

            modelBuilder.Entity<OccupationType>(entity =>
            {
                entity.HasKey(e=>e.OccupationTypeId);
                entity.HasIndex(e => e.OccupationId);

                entity.Property(e => e.Type).IsRequired();

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.OccupationType)
                    .HasForeignKey(d => d.OccupationId);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e=>e.PatientId);
                entity.Property(e => e.Gender).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Treatment>(entity =>
            {
                entity.HasKey(e => e.TreatmentId);
                entity.HasIndex(e => e.DiseaseId);

                entity.HasIndex(e => e.HospitalId);

                entity.HasIndex(e => e.PatientId);

                entity.Property(e => e.Isfatility).IsRequired();

                entity.Property(e => e.PercentageCure).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Disease)
                    .WithMany(p => p.Treatment)
                    .HasForeignKey(d => d.DiseaseId);

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Treatment)
                    .HasForeignKey(d => d.HospitalId);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Treatment)
                    .HasForeignKey(d => d.PatientId);
            });
            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(l=>l.LoginId);
                entity.Property(l => l.UserName).IsRequired();

                entity.Property(l => l.Password).IsRequired();
            });

        }

    }
}
