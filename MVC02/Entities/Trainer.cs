using MVC02.Entities.Enums;

namespace MVC02.Entities
{
    public class Trainer:GymUser
    {
        public DateTime HireDate { get; set; }
        public string Speciality { get; set; } = default!;

        public ICollection<Session> Sessions { get; set; } = new HashSet<Session>();


    }
}
