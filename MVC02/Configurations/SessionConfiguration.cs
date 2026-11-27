using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC02.Entities;

namespace MVC02.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(s => s.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_Session_Capacity", "Capacity BETWEEN 1 AND 25");
                t.HasCheckConstraint("CK_Session_EndDate", "EndDate>startDate");

            });

            builder.HasOne(s => s.Trainer).
                WithMany(t => t.Sessions).
                HasForeignKey(s => s.TrainerId).
                OnDelete(DeleteBehavior.Restrict);
        }
    }
}
