using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Interface;
using MVC.Models;
using MVC.Repository;

namespace MVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(MVC_Context context, ICourseRepository courseRepository) 
        {
            _courseRepository = courseRepository; 
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Course> courses = await _courseRepository.GetAll();
            if (ModelState.IsValid)
            {
                RedirectToAction("Empty"); 
            }
            return View(courses);
        }

        public async Task<IActionResult> Detail(int id) 
        {
            Course course = await _courseRepository.GetByIdAsync(id);
            return View(course);
        }

        public IActionResult Create() 
        {
            return View("Create");
        }

        public IActionResult Add(Course course) 
        {
           _courseRepository.Add(course);   
            return RedirectToAction("Create");
        }

        public async Task<IActionResult> AddSkill(int id, int course)
        {
            _courseRepository.AddSkillToCourse(id, course);
            Course currentCourse = await _courseRepository.GetByIdAsync(course);
            return RedirectToAction("Edit", currentCourse);
        }

        public async Task<IActionResult> AddMaterial(int id, int course)
        {
            _courseRepository.AddMaterialToCourse(id, course);
            Course currentCourse = await _courseRepository.GetByIdAsync(course);
            return RedirectToAction("Edit", currentCourse);
        }

        public async Task<IActionResult> Edit(int id) 
        {
            Course course = await _courseRepository.GetByIdAsync(id);
            return View(course);    
        }

        public async Task<IActionResult> Delete(int id)
        {
            Course course = await _courseRepository.GetByIdAsync(id);
            _courseRepository.Delete(course);
            return RedirectToAction("Index");   
        }

        public async Task<IActionResult> Save(int id, Course newCourse)
        {
            Course course = _courseRepository.GetAllList().Where(s => s.Id == id).FirstOrDefault();

            var name = newCourse.Name;
            var number = newCourse.Description;

            course.Description = number;
            course.Name = name;
            _courseRepository.Save();

            return RedirectToAction("Index");
        }

        public void FinishCourse(int id, User loggedinUser)
        {
            _courseRepository.FinishCourse(id, loggedinUser);       
        }
    }
}