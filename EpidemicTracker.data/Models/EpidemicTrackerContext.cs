using Microsoft.EntityFrameworkCore;
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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=EpidemicTrackerDB;Integrated Security=True");
        }
    }
}
