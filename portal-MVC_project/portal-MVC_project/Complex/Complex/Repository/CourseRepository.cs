using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Complex.Data;
using Complex.Interfaces;
using Complex.Models;
using Microsoft.EntityFrameworkCore;

namespace Complex.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly PortalContext _context;

        public CourseRepository(PortalContext context)
        {
            _context = context;
        }

        public bool Add(Course course)
        {
            _context.Add(course);
            return Save();
        }

        public bool Delete(Course course)
        {
            _context.Remove(course);
            return Save();  
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.Where(c => c.ID == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Course>> GetCourseByUserId(int id)
        {
            return await _context.Courses.Where(c => c.UserID == id).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;    
        }

        public bool Update(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
