using EfCoreExamples.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreExamples.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        { }

        public MainDbContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(opt =>
            {
                opt.HasKey(s => s.IdStudent);
                opt.Property(s => s.IdStudent).ValueGeneratedOnAdd();
                opt.Property(s => s.FirstName).IsRequired()
                                             .HasMaxLength(100);

                opt.Property(s => s.LastName).IsRequired()
                                            .HasMaxLength(150);

                opt.Property(s => s.Address).IsRequired()
                                           .HasMaxLength(100);

                opt.HasOne(s => s.Status)
                       .WithMany(st => st.Students)
                       .HasForeignKey(s => s.IdStatus);
            });

            modelBuilder.Entity<Status>(opt =>
            {
                opt.HasKey(s => s.IdStatus);
                opt.Property(s => s.IdStatus).ValueGeneratedOnAdd();
                opt.Property(s => s.Name).IsRequired()
                                        .HasMaxLength(100);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                        .UseLazyLoadingProxies()
                        .LogTo(Console.WriteLine)
                        .UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=pgago;Integrated Security=True");
        }
    }
}
