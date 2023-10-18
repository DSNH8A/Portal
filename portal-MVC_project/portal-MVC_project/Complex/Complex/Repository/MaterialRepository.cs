using Complex.Data;
using Complex.Interfaces;
using Complex.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly PortalContext _context;

        public MaterialRepository(PortalContext context) 
        {
            _context = context;    
        }

        public bool Add(Material material)
        {
            _context.Materials.Add(material);   
            return Save();
        }

        public bool Delete(Material material)
        {
            _context.Materials.Remove(material);
            return Save();
        }

        public async Task<IEnumerable<Material>> GetAll()
        {
            return await _context.Materials.ToListAsync();
        }

        public async Task<Material> GetByIdAsync(int id)
        {
            return await _context.Materials.Where(m => m.ID == id).FirstOrDefaultAsync();        
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false; 
        }

        public bool Update(Material material)
        {
            throw new NotImplementedException();
        }
    }
}
