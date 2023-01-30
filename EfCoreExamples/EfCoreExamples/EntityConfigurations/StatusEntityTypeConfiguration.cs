using EfCoreExamples.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreExamples.EntityConfigurations
{
    public class StatusEntityTypeConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(s => s.IdStatus);
            builder.Property(s => s.IdStatus).ValueGeneratedOnAdd();
            builder.Property(s => s.Name).IsRequired()
                                    .HasMaxLength(100);
        }
    }
}
