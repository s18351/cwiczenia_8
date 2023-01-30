using EfCoreExamples.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreExamples.EntityConfigurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.IdStudent);
            builder.Property(s => s.IdStudent).ValueGeneratedOnAdd();
            builder.Property(s => s.FirstName).IsRequired()
                                         .HasMaxLength(100);

            builder.Property(s => s.LastName).IsRequired()
                                        .HasMaxLength(150);

            builder.Property(s => s.Address).IsRequired()
                                       .HasMaxLength(100);

            builder.HasOne(s => s.Status)
                   .WithMany(st => st.Students)
                   .HasForeignKey(s => s.IdStatus);
        }
    }
}
