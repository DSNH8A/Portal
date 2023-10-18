using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Models
{
    public class Skill
    {
        public int ID { get; set; }

        public int ?CourseId { get; set; }
        public int SkillLevel { get; set; }

        public string Name { get; set; }    

        public enum SkillType
        {
            something, 
            anything, 
            everything
        }
    }
}
