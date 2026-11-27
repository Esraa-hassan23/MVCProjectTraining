using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC02.Entities;

namespace MVC02.Configurations
{
    public class MemberShipConfiguration : IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(EntityTypeBuilder<MemberShip> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasOne(m => m.Plan).
                WithMany(p => p.PlanSubscriptions).
                HasForeignKey(m => m.PlanId).
                OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Member).
                WithMany(m => m.MemberSubscriptions).
                HasForeignKey(m => m.MemberId).
                OnDelete(DeleteBehavior.Restrict);
             
        }
    }
}
