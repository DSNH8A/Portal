using MVC.Models;

namespace MVC.Interface
{
    public interface IUserRepository
    {

        public static User loggedInUser;

        public User LoggedinUser();
        public Task<User> GetByUserName(string userName);
        public Task<User> GetByPassword(string password);
        public Task<IEnumerable<Course>> GetCourses(int id);

        public Task<User> GetByIdAsync(int id);

        public List<Course> GetCoursesList(int id);

        public List<Material> GetUsersMaterials(int id);

        public List<Skill> GetUsersSkills(int id);

        public Task<IEnumerable<User>> GetAll();

        public List<User> GetAllList();

        public bool Login(string userName, string password);

        public void AddCourseToUser(int id, int userID);

        public List<Skill> SortSkills(List<Skill> skills);

        public List<Material> SortMaterials(List<Material> materials);

        public void Add(User user);
    }
}
