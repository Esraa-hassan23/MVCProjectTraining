using Microsoft.EntityFrameworkCore;
using MVC02.Entities;

namespace MVC02.Configurations
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Plan> builder)
        {
            builder.ToTable(t => t.HasCheckConstraint("CK_Plan_DurationDays", "DurationDays between 1 and 365"));
        }
    }
}
