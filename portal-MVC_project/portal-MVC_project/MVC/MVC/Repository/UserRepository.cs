using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data; 
using MVC.Interface;
using MVC.Models;

namespace MVC.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly MVC_Context _context;

        public User LoggedinUser()
        {
            return IUserRepository.loggedInUser;
        }

        public UserRepository(MVC_Context context)
        {
            _context = context; 
        }

        public async Task<User> GetByUserName(string userName)
        {
            return await _context.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<User> GetByPassword(string password)
        {
            return await _context.Users.Where(u => u.Password == password).FirstOrDefaultAsync();     
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync(); 
        }

        public List<User> GetAllList()
        {
            return _context.Users.ToList(); 
        }

        public async Task<IEnumerable<Course>> GetCourses(int id)
        {
            return await _context.courses.Where(c => c.UserID == id).ToListAsync();
        }

        public List<Course> GetCoursesList(int id)
        {
            return _context.courses.Where(c => c.UserID == id).ToList();
        }

        public bool Login(string userName, string password)
        {
            foreach (var item in _context.Users)
            {
                if (item.UserName == userName && item.Password == password)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            return false;
        }

        public async Task AddSkillToUser(int id, int courseId)
        {
            Skill skill = _context.Skills.Where(s => s.Id == id).FirstOrDefault();
            List<Skill> skills = _context.Skills.ToList();

            foreach (var item in skills)
            {
                if (item.CourseId == courseId && item.Name == skill.Name)
                {
                    Console.WriteLine("You already have this skill.");
                    return;
                }
            }

            if (skill.CourseId != null)
            {
                Skill newSkill = new Skill()
                {
                    Name = skill.Name,
                    SkillLevel = 0,
                    CourseId = courseId,
                };

                _context.Skills.Add(newSkill);
                _context.SaveChanges();
            }

            else
            {
                skill.CourseId = courseId;
            }
            _context.SaveChanges();
        }

        public List<Material> GetUsersMaterials(int id)
        {
            List<Material> materials = _context.Materials.Where(m => m.UserId == id).ToList();
            return SortMaterials(materials);
        }

        public List<Skill> GetUsersSkills(int id)
        {
            List<Skill> skills = _context.Skills.Where(s => s.UserId == id).ToList();
            return SortSkills(skills);
        }

        public void AddCourseToUser(int id, int userId)
        {
            Course course = _context.courses.Where(c => c.Id == id).FirstOrDefault(); 
            course.UserID = userId;
            _context.SaveChanges();
        }

        public List<Skill> SortSkills(List<Skill> skills)
        {
            int id = LoggedinUser().Id;

            for (int i = 0; i < skills.Count; i++) 
            {
                for (int j = i + 1; j < skills.Count; j++)
                {
                    if (skills[i].Name == skills[j].Name)
                    {
                        skills[i].SkillLevel++;
                        skills.Remove(skills[j]);
                    }
                }
            }

            return skills;  
        }

        public List<Material> SortMaterials(List<Material> materials) 
        {
            int id = LoggedinUser().Id;

            for (int i = 0; i < materials.Count; i++)
            {
                for(int j = i+1; j < materials.Count; j++)
                {
                    if (materials[i].Name == materials[j].Name)
                    {
                        materials.Remove(materials[j]);
                    }
                }
            }

            return materials;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();    
        }
    }
}
