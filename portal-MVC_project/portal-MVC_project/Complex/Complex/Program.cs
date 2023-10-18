
using Complex;
using Complex.Data;
using Complex.Models;


public class Program
{
    public static User loggedInUser;
    public static Course currentCourse;

    public static void Main()
    {
        Console.WriteLine("Username: ");
        string userName = Console.ReadLine();
        Console.WriteLine("Password: ");
        string password = Console.ReadLine();
        
        loggedInUser = FileOperations.Instance.GetUser(userName, password);

        if (loggedInUser == null)
        {
            Console.WriteLine("If you want to create a user profile press 1");
        }

        if (loggedInUser != null)
        {
            Console.WriteLine("Here are your courses: ");
           
            Console.WriteLine("Available courses: ");
            Console.WriteLine("-----------");
            FileOperations.Instance.GetCoursesOfUser(loggedInUser.Id);
            Console.WriteLine("-----------");
            Console.WriteLine("Corses in progress: ");
            Console.WriteLine("-----------");
            FileOperations.Instance.GetCoursesInProgress(loggedInUser.Id);
            Console.WriteLine("-----------");
            Console.WriteLine("Finished courses");
            Console.WriteLine("-----------");
            FileOperations.Instance.GetFinishedCourses(loggedInUser.Id);
            Console.WriteLine("-----------");


            Console.WriteLine("You can add courses to your profile to do that type add. " +
                "Or you can Finish your courses to gains skills, to do that type the courses name");

            string command = Console.ReadLine();    

            if(command == "add")
            {
                Feri();
                Console.WriteLine("If you want to add any of the above type its name");
                string courseName = Console.ReadLine();
                FileOperations.Instance.AddCourseToUser(loggedInUser.Id, courseName);
                Console.WriteLine("Your course is successfully added to your profile.");
            }

            currentCourse = SearchForCourse(command);
            if (currentCourse != null)
            {
                Console.WriteLine("You have selected: " + currentCourse.Name);
                Console.WriteLine("You can finish this course to do that type finish.");
                Console.WriteLine("You can add skills to your courses to do that type skill");

                string finish = Console.ReadLine();
                if (finish == "skill")
                {
                    Console.WriteLine("Here are all the skills.");
                    FileOperations.Instance.GetAllSkills();
                    Console.WriteLine("Type the id of the one you want to add and the course id.");
                    int skillid = Convert.ToInt32(Console.ReadLine());
                    int courseid = Convert.ToInt32(Console.ReadLine());

                    FileOperations.Instance.AddSkillToCourse(courseid, skillid, loggedInUser);
                    Console.WriteLine("Skill sucessfully added to your course.");
                }

                if(finish == "finish") 
                {
                    FileOperations.Instance.FinishCourse(currentCourse.ID, loggedInUser.Id);
                    Console.WriteLine("You succesfully completed this course.");
                }
            }
        }

        if (Console.ReadLine() == "1")
        {
            Console.WriteLine("Add your username");
            string newUserName = Console.ReadLine();

            Console.WriteLine("Add your password");
            string newPassword = Console.ReadLine();
            CreateUser(newUserName, newPassword);
        }
    }

    public static User GetUser(string userName, string password)
    {
        using PortalContext context = new PortalContext();
        List<User> users = context.Users.ToList();

        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].UserName == userName || users[i].Password == password)
            {
                return users[i];
            }
        }

        Console.WriteLine("There is no such user");
        return default;
    }

    public static void CreateUser(string userName, string password)
    {
        FileOperations.Instance.CreateUser(userName, password);    
    }

    public static void Feri()
    {
        List<Course> courses = FileOperations.Instance.GetCourses();

        foreach (var item in courses)
        {
            Console.WriteLine("Course name: " + item.Name);
            Console.WriteLine("Course description: " + item.Description);
            Console.WriteLine("Course id: " + item.ID);
            Console.WriteLine("-------------------");
        }
    }

    public static Course SearchForCourse(string courseName)
    {
        List<Course> courses = FileOperations.Instance.GetCoursesOfUser(loggedInUser.Id);
        
        for (int i = 0; i < courses.Count; i++) 
        {
            if (courses[i].Name == courseName)
            {
                return courses[i]; 
            }
        }

        return default;
    }
}