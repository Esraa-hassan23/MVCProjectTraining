using System.ComponentModel.DataAnnotations.Schema;

namespace MVC02.Entities
{
    public class MemberShip:BaseClass
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int PlanId { get; set; }
        public Plan Plan { get; set; } = default!;

        public int MemberId { get; set; }
        public Member Member { get; set; } = default!;

        //Computed prop
        [NotMapped]
        public string Status => StartDate > DateTime.Now ? "Upcoming" :
        
            EndDate > DateTime.Now ? "Active" : "Expired";


    }
}
