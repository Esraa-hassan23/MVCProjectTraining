using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC02.Context;
using MVC02.Entities;
using MVC02.Interfaces;
using MVC02.Repository;
using MVC02.ViewModels;

namespace MVC02.Controllers
{
    public class PlanController : Controller
    {
        private readonly IPlanRepository _PlanRepo;
        private readonly IMemberShipRepository _MemberShipRepo;

       public PlanController([FromKeyedServices("planRepo")] IPlanRepository planRepository,[FromKeyedServices("MembershipRepo")]IMemberShipRepository membershipRepository)
        {
            _PlanRepo = planRepository;
            _MemberShipRepo = membershipRepository;
        }

        public async Task<IActionResult> Index(CancellationToken ct =default)
        {
            var plans =await _PlanRepo.GetAllPlansAsync(ct);
            var planViewModel = plans.Select(p => new PlanViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                DurationDays = p.DurationDays,
                Price = p.Price,
                IsActive = p.IsActive
            });

            return View(planViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id , CancellationToken ct = default)
        {
            //if (id < 0)
            //{
            //    return NotFound();
            //}

            var plan = await  _PlanRepo.FindPlanByIdAsync(id, ct);

            if (plan is null || !plan.IsActive)
            {
                TempData["ErrorMessage"] = "This Plan Can NOt be edited!!!";
                return RedirectToAction(nameof(Index));
            }
            var isPlanHasMemberShipAsync = await _MemberShipRepo.AnyAsync(m => m.PlanId == plan.Id && m.EndDate > DateTime.Now , ct);

            if (isPlanHasMemberShipAsync)
            {
                TempData["ErrorMessage"] = "This Plan Can NOt be edited!!!";
                return RedirectToAction(nameof(Index));
            }

            var viewplan = new UpdatedPlanViewModel()
            {
                Description = plan.Description,
                Price = plan.Price,
                DurationDays = plan.DurationDays,
                PlanName = plan.Name
            };

            return View(viewplan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id , UpdatedPlanViewModel updatedPlan , CancellationToken ct)
        {
            if (!ModelState.IsValid) { return View(updatedPlan); }

            var plan = await _PlanRepo.FindPlanByIdAsync(id, ct);

            if (plan is null || !plan.IsActive)
            {
                TempData["ErrorMessage"] = "This Plan Can NOt be edited!!!";
                return RedirectToAction(nameof(Index));
            }
            var isPlanHasMemberShipAsync = await _MemberShipRepo.AnyAsync(m => m.PlanId == plan.Id && m.EndDate > DateTime.Now, ct);

            if (isPlanHasMemberShipAsync)
            {
                TempData["ErrorMessage"] = "This Plan Can NOt be edited!!!";
                return RedirectToAction(nameof(Index));
            }

            plan.Price = updatedPlan.Price;
            plan.DurationDays = updatedPlan.DurationDays;
            plan.Description = updatedPlan.Description;
            plan.UpdatedAt = DateTime.Now;

            bool isPlanSaved = await _PlanRepo.UpdatedPlanAsync(ct) > 0;
            if (isPlanSaved)
            {
                TempData["SuccessMessage"] = "Plan Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error happened while updating the Plan ");
                return View(updatedPlan);
            }
        }
    }
}
