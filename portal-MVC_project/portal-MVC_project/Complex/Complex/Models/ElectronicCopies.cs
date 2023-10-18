using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Models
{
    public class ElectronicCopies : Material
    {
        public string Author { get; set; }

        public int NumberOgpages { get; set; }

        public string Format { get; set; }

        public DateTime YearOfPublication { get; set; }
    }
}
