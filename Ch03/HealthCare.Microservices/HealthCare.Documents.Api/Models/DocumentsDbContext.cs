using HealthCare.Documents.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Doctors.Api.Models
{
    public class DocumentsDbContext : DbContext
    {
        public DocumentsDbContext(DbContextOptions<DocumentsDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=Documents.db");

        public DbSet<Document> Documents { get; set; }
    }

}
