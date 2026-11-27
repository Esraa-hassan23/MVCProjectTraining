using Microsoft.EntityFrameworkCore;
using MVC02.Context;
using MVC02.Entities;
using MVC02.Interfaces;


namespace MVC02.Repository
{
    public class PlanRepository : IPlanRepository
    {
        private readonly GymDbContext _DbContext;

        public PlanRepository(GymDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<Plan?> FindPlanByIdAsync(int id, CancellationToken ct)
        {
            return await _DbContext.Plans.FindAsync([id], ct);
        }

        public async Task<IEnumerable<Plan>> GetAllPlansAsync(CancellationToken ct =default)
        {
            return await _DbContext.Plans.AsNoTracking().ToListAsync(ct);
        }

        public async Task<int> UpdatedPlanAsync(CancellationToken ct)
        {
            try
            {
                 return await _DbContext.SaveChangesAsync(ct);
            }
            catch ( DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return 0 ;
            }
        }
    }
}
