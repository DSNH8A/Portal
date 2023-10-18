using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Complex.Models;

namespace Complex.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();

        Task<Course> GetByIdAsync(int id);

        Task<IEnumerable<Course>> GetCourseByUserId(int id);

        bool Add(Course course);

        bool Delete(Course course);

        bool Update(Course course);

        bool Save();
    }
}
