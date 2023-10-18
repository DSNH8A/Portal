using MVC.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Material : Entity
    {
        public int Id { get; set; } 

        public int ?CourseId { get; set; }

        public int ?UserId { get; set; }    

        public string Name { get; set; }

        //Electronic copies
        public string ?Author { get; set; }

        public int ?NumberOgpages { get; set; }

        public string ?Format { get; set; }

        public DateTime ?YearOfPublication { get; set; }

        //OnlineArticles

        public DateTime ?DateOfPublication { get; set; }

        public string ?TypeOfDatacarrier { get; set; }

        //VideoMaterial
        public float ?Duration { get; set; }

        public string ?Quality { get; set; }
    }
}
