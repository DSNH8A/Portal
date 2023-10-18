using Complex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Interfaces
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> GetAll();

        Task<Skill> GetByIdAsync(int id);

        bool Add(Skill skill);

        bool Delete(Skill skill);

        bool Update(Skill skill);

        bool Save();
    }
}
