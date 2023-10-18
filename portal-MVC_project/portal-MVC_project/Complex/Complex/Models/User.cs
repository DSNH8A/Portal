using Complex.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Models
{
    public class User
    {

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
            dateOfJoining = DateTime.Now;
        }

        public int Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime dateOfJoining { get; set; }

        public ICollection<Course> AvailableCourses { get; set; } = null!;
        
        public ICollection<Skill> UserSkills { get; set; } = null!;

        public ICollection<Material> UserMaterials { get; set; } = null!;

    }
}