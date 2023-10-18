using Complex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();

        Task<User> GetByIdAsync(int id);

        //Task<IEnumerable<Course>> GetUserByUserId(int id);

        bool Add(User user);

        bool Delete(User user);

        bool Update(User user);

        bool Save();
    }
}
