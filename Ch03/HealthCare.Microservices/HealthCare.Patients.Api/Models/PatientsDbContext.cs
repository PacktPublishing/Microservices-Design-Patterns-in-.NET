using Microsoft.EntityFrameworkCore;

namespace HealthCare.Patients.Api.Models;

public class PatientsDbContext : DbContext
{
    public PatientsDbContext(DbContextOptions<PatientsDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=Patients.db");
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Document> Documents { get; set; }
}
