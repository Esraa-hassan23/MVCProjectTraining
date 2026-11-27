using MVC02.Entities;

namespace MVC02.Interfaces
{
    public interface IPlanRepository
    {
        public Task<IEnumerable<Plan>> GetAllPlansAsync(CancellationToken ct = default);
        public Task<Plan?> FindPlanByIdAsync(int id, CancellationToken ct = default);

        public Task<int> UpdatedPlanAsync(CancellationToken ct);
    }
}
