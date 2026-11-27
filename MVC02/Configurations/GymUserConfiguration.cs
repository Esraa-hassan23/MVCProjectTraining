using Microsoft.EntityFrameworkCore;
using MVC02.Entities;

namespace MVC02.Configurations
{
    public class GymUserConfiguration<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Name).HasColumnType("NVARCHAR").HasMaxLength(50);

            builder.Property(x => x.Email).HasColumnType("NVARCHAR").HasMaxLength(100);
            builder.Property(x => x.Phone).HasColumnType("NVARCHAR").HasMaxLength(11);

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_Trainer_Email", "Email LIKE '_%@_%._%'");
                t.HasCheckConstraint("CK_Trainer_EgyPhone", "LEN(Phone)=11 AND (Phone LIKE '010%' OR Phone LIKE '011%' OR Phone LIKE '012%' OR Phone LIKE '015%')");
            });

            builder.ComplexProperty(x => x.Address);
        }
    }
}
