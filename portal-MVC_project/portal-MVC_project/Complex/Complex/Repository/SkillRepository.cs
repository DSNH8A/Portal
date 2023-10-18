using Complex.Data;
using Complex.Interfaces;
using Complex.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly PortalContext _context;

        public SkillRepository(PortalContext context)
        {
            _context = context;
        }   

        public bool Add(Skill skill)
        {
            _context.Skills.Add(skill);
            return Save();
        }

        public bool Delete(Skill skill)
        {
            _context.Skills.Remove(skill);
            return Save();  
        }

        public async Task<IEnumerable<Skill>> GetAll()
        {
            return await _context.Skills.ToListAsync(); 
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            return await _context.Skills.Where(s => s.ID == id).FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Skill skill)
        {
            throw new NotImplementedException();
        }
    }
}
