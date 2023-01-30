using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class HealthDbContext : DbContext
    {
        public HealthDbContext()
        {

        }

        public HealthDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                        .LogTo(Console.WriteLine)
                        .UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s18351;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>(opt =>
            {
                opt.HasData(
                    new Doctor { IdDoctor = 1, Email = "test@example.com", FirstName = "Gucio", LastName = "Truteń"},
                    new Doctor { IdDoctor = 2, Email = "panimajowa@example.com", FirstName = "Pszczółka", LastName = "Maja" }
                    );
            });

            modelBuilder.Entity<Patient>(opt =>
            {
                opt.HasData(
                    new Patient { IdPatient = 1, FirstName = "Grzegorz", LastName = "Brzeczyszczykiewicz", Birthdate = new DateTime(1990, 9, 10) },
                    new Patient { IdPatient = 2, FirstName = "Joszko", LastName = "Broda", Birthdate = new DateTime(1990, 10, 10) }
                    );
            });
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
    }
}
