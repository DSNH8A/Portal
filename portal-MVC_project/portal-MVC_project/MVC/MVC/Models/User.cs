using MVC.BaseEntity;

namespace MVC.Models
{
    public class User : Entity
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime dateOfJoining { get; set; }

        public ICollection<Course> AvailableCourses { get; set; } = null!;

        public ICollection<Skill> UserSkills { get; set; } = null!;

        public ICollection<Material> UserMaterials { get; set; } = null!;
    }
}
