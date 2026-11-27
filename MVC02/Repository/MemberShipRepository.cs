using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MVC02.Context;
using MVC02.Entities;
using MVC02.Interfaces;

namespace MVC02.Repository
{
    public class MemberShipRepository : IMemberShipRepository
    {
        private readonly GymDbContext _DbContext;
       public MemberShipRepository(GymDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<bool> AnyAsync(Expression<Func<MemberShip, bool>> predicate, CancellationToken ct)
        {
            return await _DbContext.MemberShips.AnyAsync(predicate, ct);
        }

       

    }
}
