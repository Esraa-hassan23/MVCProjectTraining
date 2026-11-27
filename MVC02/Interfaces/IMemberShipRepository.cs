using System.Linq.Expressions;
using MVC02.Entities;

namespace MVC02.Interfaces
{
    public interface IMemberShipRepository
    {
         Task<bool> AnyAsync(Expression<Func<MemberShip,bool>> predicate,CancellationToken ct);
    }
}
