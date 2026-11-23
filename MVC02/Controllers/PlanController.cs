using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC02.Context;

namespace MVC02.Controllers
{
    public class PlanController : Controller
    {
        private readonly GymDbContext DbContext = new ();
        public async Task<IActionResult> Index()
        {
            var plans = await DbContext.Plans.ToListAsync();

            return View(plans);
        }
    }
}
