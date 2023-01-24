using PatientInformation.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace PatientInformation.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Disease> Disease { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<PatientNCDs> PatientNCDs { get; set; }
        public DbSet<PatientAllergies> PatientAllergies { get; set; }
        public DbSet<NonCommunicableDisease> NonCommunicableDiseases { get; set; }

    }
}
