using Complex.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Models
{
    public class Course : Entity
    {
        public int ID { get; set; }

        public int ?UserID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public double ProgressInPercentage { get; set; }

        public ICollection<Skill> Skills { get; set; } = null!;

        public ICollection<Material> Materials { get; set; } = null!;

        void AddNewMaterials(Skill skill)
        {
            GetSkills().Remove(skill);
        }

        public void AddNewSkills(Skill skill)
        {
            GetSkills().Add(skill);
        }

        public ICollection<Skill> GetSkills()
        {
            PortalContext context = new PortalContext();
            return Skills = context.Skills.Where(s => s.CourseId == ID).ToList();
        }

        public void CompleteCourse()
        {
            ProgressInPercentage = 100.00;
        }
    }
}
