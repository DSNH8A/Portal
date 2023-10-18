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
    public class UserRepository : IUserRepository
    {
        private readonly PortalContext _context;

        public UserRepository(PortalContext context)
        {
            _context = context;
        }

        public bool Add(User user)
        {
            _context.Users.Add(user);   
            return Save();
        }

        public bool Delete(User user)
        {
            _context.Users.Remove(user);
            return Save();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(User course)
        {
            throw new NotImplementedException();
        }
    }
}
