using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RandomUser.Api.Data.Models;

namespace RandomUser.Api.Data.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .IsRequired(true)
            .HasColumnType("VARCHAR(160)");
        
        builder.Property(x => x.Email)
            .IsRequired(true)
            .HasColumnType("VARCHAR(160)");
        
        builder.Property(x => x.Gender)
            .IsRequired(false)
            .HasColumnType("VARCHAR(10)");
        
        builder.Property(x => x.BirthDate)
            .IsRequired(false)
            .HasColumnType("TIMESTAMP");

        builder.Property(x => x.Nationality)
            .IsRequired(false)
            .HasColumnType("VARCHAR(50)");
        
        builder.Property(x => x.Address)
            .IsRequired(false)
            .HasColumnType("VARCHAR(255)");
        
        builder.Property(x => x.Phone)
            .IsRequired(false)
            .HasColumnType("VARCHAR(20)");
        
        builder.Property(x => x.Mobile)
            .IsRequired(false)
            .HasColumnType("VARCHAR(20)");
        
        builder.Property(x => x.CreateAt)
            .IsRequired(true)
            .HasColumnType("TIMESTAMP");
        
        builder.Property(x => x.UpdateAt)
            .IsRequired(true)
            .HasColumnType("TIMESTAMP");
    }
}