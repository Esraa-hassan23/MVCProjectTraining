using System.ComponentModel.DataAnnotations;

namespace MVC02.ViewModels
{
    public class UpdatedPlanViewModel
    {
        [Display(Name = "Plan")]
        public string PlanName { get; set; } = default!;


        [Required(ErrorMessage ="Price is required")]
        [Range(0.01,10000,ErrorMessage ="Price Higher than 10000")]
        [Display(Name = "Price (EGP)")]
        public decimal Price { get; set; }



        [Required(ErrorMessage ="Duration Days is required")]
        [Range(1,365,ErrorMessage ="Duration Days range between 1 -> 365 days")]
        [Display(Name ="Duration ()")]
        public int DurationDays { get; set; }


        [StringLength(200, MinimumLength = 5, ErrorMessage = "Description must be between 5 t0 200 chars")]
        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; } = default!;

    }
}
