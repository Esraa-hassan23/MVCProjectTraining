using MVC02.Entities.Enums;

namespace MVC02.Entities
{
    public class GymUser :BaseClass
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public DateTime DOB { get; set; }
        public Address Address { get; set; } = default!;
        public Gender Gender { get; set; }
    }
}
