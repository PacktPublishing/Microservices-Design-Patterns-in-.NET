using Microsoft.EntityFrameworkCore;

namespace HealthCare.Patients.Api.Models
{
    public class ApplicationDatabaseContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=patients.db");
        }
    }

}
