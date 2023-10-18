using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Complex.Data;
using Complex.Models;

namespace Complex
{
    public  partial class FileOperations
    {
        private static FileOperations instance = new FileOperations();
        public readonly PortalContext _context = new PortalContext();

        public static FileOperations Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }

                else 
                {
                    return instance = new FileOperations();
                }
            }
        }

        public void CreateUser(string userName, string password)
        {
            User user = new User(userName, password);
            user.dateOfJoining = DateTime.Now;

            _context.Users.Add(user);   
        }

        public User GetUser(string userName, string password)
        {
            List<User> users = _context.Users.ToList();

            for (int i = 0; i < users.Count(); i++)
            {
                if (users[i].UserName == userName && users[i].Password == password)
                {
                    return users[i];    
                }
            }

            Console.WriteLine("There is no such user");
            return default;
        }

        #region Courses

        public void CreateCourse(string name, string description)
        {
            Course course = new Course()
            {
                Name = name,
                Description = description
            };

            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public List<Course> GetCourses()
        {
            List<Course> courseList = _context.Courses.ToList();
            return courseList.DistinctBy(x => x.Name).ToList(); 
        }

        public List<Course> GetCoursesOfUser(int userId)
        {
            List<Course> courses = _context.Courses.Where(c => c.UserID == userId).ToList();
            foreach (var item in courses)
            {
                Console.WriteLine("Course name: " + item.Name);
                Console.WriteLine("Course Id: " + item.ID);
                Console.WriteLine("---------");
            }

            return courses;
        }

        public List<Course> GetCoursesInProgress(int userId)
        {
            List<Course> courses = _context.Courses.Where(c => c.UserID == userId).ToList();
            courses = courses.Where(c => c.ProgressInPercentage > 0).ToList();
            courses = courses.Where(c => c.ProgressInPercentage < 100).ToList();

            foreach (var item in courses)
            {
                Console.WriteLine(item.Name);    
            }

            return courses;
        }

        public List<Course> GetFinishedCourses(int userId)
        {
            List<Course> courses = _context.Courses.Where(c => c.UserID == userId).ToList();
            courses = courses.Where(c => c.ProgressInPercentage == 100.00).ToList();

            foreach (var item in courses)
            {
                Console.WriteLine(item.Name);    
            }

            return courses;
        }

        public void AddCourseToUser(int userId, string courseName)
        {
            User user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            Course course = _context.Courses.Where(c => c.Name == courseName).FirstOrDefault();

            if (course.UserID == userId)
            {
                Console.WriteLine("You already own this course.");
                return;
            }

            if (course.UserID != null)
            {
                Course newCourse = new Course()
                {
                    Name = course.Name,
                    Description = course.Description,
                    ProgressInPercentage = 0.00,
                    Materials = course.Materials,
                    Skills = course.Skills,
                    UserID = userId
                };

                _context.Courses.Add(newCourse);
                //_context.SaveChanges();
            }
        }

        public void FinishCourse(int courseId, int userId)
        {
            Course course = _context.Courses.Where(c => c.ID == courseId).FirstOrDefault();

            if (course.UserID == userId)
            {
                course.ProgressInPercentage = 100.00;
                _context.SaveChanges();
            }

            else 
            {
                Console.WriteLine("This user doesnt have this course");
            }
        }

        public void AddMaterialToCourse(int courseId, int materialId, User loggedinUser)
        {
            Course course = _context.Courses.Where(c => c.ID == courseId).FirstOrDefault();
            Material material = _context.Materials.Where(m => m.ID == materialId).FirstOrDefault();

            material.CourseId = courseId;
            _context.SaveChanges();

            Console.WriteLine("You are not authorized to do this");
        }

        public void AddSkillToCourse(int courseId, int skillId, User loggedinUser)
        {
            Course course = _context.Courses.Where(c => c.ID == courseId).FirstOrDefault();
            Skill skill = _context.Skills.Where(s => s.ID == skillId).FirstOrDefault();

            Skill newSkill = new Skill()
            {
                Name = skill.Name,
                CourseId = courseId,
                SkillLevel = 0,
            };

            _context.Skills.Add(newSkill);
        }

        public void GetMaterialsFromCourse(int courseId)
        {
            List<Material> materials = _context.Materials.Where(m => m.CourseId == courseId).ToList();
            
            foreach (Material material in materials) 
            {
                Console.WriteLine(material.Name);    
            }
        }

        public void GetSkillsFromCourse(int courseId)
        {
            List<Skill> skills = _context.Skills.Where(s => s.CourseId == courseId).ToList();

            foreach (Skill skill in skills)
            {
                Console.WriteLine(skill.Name);
            }
        }

        public void DeleteCourse(int courseId, User loggedinUser)
        {
                Course course = _context.Courses.Where(c => c.ID == courseId).FirstOrDefault();
                _context.Courses.Remove(course);
                _context.SaveChanges();

                Console.WriteLine("You are not authorized to do this");
        }
        #endregion

        #region Skills

        public void GetAllSkills()
        {
            List<Skill> skills = _context.Skills.ToList();

            foreach (var item in skills)
            {
                Console.WriteLine("SkillName: " + item.Name);
                Console.WriteLine("Skill id: " + item.ID);
            }
        }

        public void InspectSkills(int userId)
        {
            List<Skill> skills = CheckForDuplicates(userId);

            foreach (Skill skill in skills)
            {
                Console.WriteLine(skill.Name);
                Console.WriteLine(skill.SkillLevel);
            }
        }

        public void InspectSkillLevels(int userId)
        {
            //List<Skill> skills = CheckForDuplicates(userId);
            List<Skill> skills = _context.Skills.ToList();

            foreach (Skill skill in skills)
            {
                Console.WriteLine(skill.SkillLevel);    
            }
        }

        public void DeleteSkills(int skillId)
        {
            Skill skill = _context.Skills.Where(s => s.ID == skillId).FirstOrDefault();
            _context.Skills.Remove(skill);
            _context.SaveChanges();
        }

        private List<Skill> GetSkills(int userId)
        {
            List<Course> courses = GetFinishedCourses(userId);
            List<Skill> skills = new List<Skill>();

            for (int i = 0; i < courses.Count; i++)
            {
                skills.AddRange(courses[i].Skills);
            }

            return skills;
        }

        private List<Skill> CheckForDuplicates(int userId)
        {
           
            List<Skill> skills = GetSkills(userId);

            for (int i = 0; i < skills.Count; i++)
            {
                for (int j = 1; j < skills.Count; j++)
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
        #endregion

        #region Materials

        public List<Material> GetMaterialsFromUser(int userId)
        {
            List<Material> materials = new List<Material>();
            materials = _context.Materials.Where(m => m.UserId == userId).ToList();

            foreach (Material m in materials)
            {
                Console.WriteLine(m.Name);    
            }

            return materials;
        }

        public void Add(Entity entity)
        {
            _context.Add(entity);  
            _context.SaveChanges();
        }

        #endregion
    }
}