using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Interface;
using MVC.Models;
using MVC.ViewModel;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;   

        public UserController(MVC_Context context, IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var users = _userRepository.GetAllList();
            return View();
        }

        public IActionResult Login(User user)
        {
            User storedUsers = _userRepository.GetAllList().Where(u => u.Password == user.Password).FirstOrDefault();
            return RedirectToAction("Create");
        }

        public IActionResult Create(User user) 
        {
            foreach (var item in _userRepository.GetAllList()) 
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

            _userRepository.Add(user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            User user = await _userRepository.GetByIdAsync(id);
            return View(user);
        }
    }
}
