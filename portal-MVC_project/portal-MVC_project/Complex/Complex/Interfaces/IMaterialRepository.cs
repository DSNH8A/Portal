using Complex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Interfaces
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetAll();

        Task<Material> GetByIdAsync(int id);

        bool Add(Material material);

        bool Delete(Material material);

        bool Update(Material material);

        bool Save();
    }
}
