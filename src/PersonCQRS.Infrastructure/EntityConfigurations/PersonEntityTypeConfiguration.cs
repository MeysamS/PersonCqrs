using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonCQRS.Domain.AggregatesModel;

namespace PersonCQRS.Infrastructure.EntityConfigurations
{
    public class PersonEntityTypeConfiguration:IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .UseHiLo("personseq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.Property(p => p.FirstName)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasMaxLength(400)
                .IsRequired();
            builder.HasIndex("Email")
                .IsUnique();
            
            builder.Property(p => p.Email)
                .HasMaxLength(400)
                .IsRequired();
            
            builder.Property(p => p.DateOfBirth)
                .IsRequired();
            
        }
    }
}