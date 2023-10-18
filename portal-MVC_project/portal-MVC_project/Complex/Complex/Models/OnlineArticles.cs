using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Models
{
    public class OnlineArticles :Material
    {
        public DateTime DateOfPublication { get; set; }

        public string TypeOfDatacarrier { get; set; }
    }
}
