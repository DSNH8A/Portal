using MVC.BaseEntity; 
namespace MVC.Models
{
    public class Skill : Entity 
    {
        public int Id { get; set; }

        public int? CourseId { get; set; }

        public int? UserId { get; set; }

        public int SkillLevel { get; set; }

        public string Name { get; set; }

    }
}
