using PatientInformation.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace PatientInformation.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
        //public DbSet<Country> Country { get; set; }

    }
}
