using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Models
{
    public class Material
    {
        public int ID { get; set; }

        public int UserId { get; set; }

        public int ?CourseId { get; set; }

        public string Name { get; set; }
    }
}
