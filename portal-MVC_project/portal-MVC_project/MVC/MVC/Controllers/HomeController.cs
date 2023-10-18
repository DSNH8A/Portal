using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Interface;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, MVC_Context context, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<User> Login(string userName, string password)
        {
            User user = await _userRepository.GetByUserName(userName);
            User user1 = await _userRepository.GetByPassword(password);

            if (user == user1)
            {
                IUserRepository.loggedInUser = user1;
                return user1;    
            }

            return null;
        }

        public async Task<IActionResult> Detail(int id, string userName, string password)
        {
            
            User user = await Login(userName, password);
            if (user != null)
            {
                return View(user);
            }

            else 
            {
                return RedirectToAction("Create");
            }
        }

        public IActionResult Add(User user)
        {
            List<User> users = _userRepository.GetAllList();

            foreach (var item in users)
            {
                if (item.Password == user.Password)
                {
                    Console.WriteLine();
                }

                if (item.UserName == user.UserName)
                {
                    Console.WriteLine();
                }
            }

            user.dateOfJoining = DateTime.Now;
            _userRepository.Add(user);
            return RedirectToAction("Index");
        }

        public IActionResult Create(User user)
        {

            return View(user);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AddCourse()
        {
            return View("AddCourse");
        }

        public IActionResult AddCourseToUser(int id, int userId)
        {
            _userRepository.AddCourseToUser(id, userId);
            return RedirectToAction("Detail");
        }
    }
}