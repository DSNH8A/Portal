using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Interface;
using MVC.Models;
using MVC.Repository;

namespace MVC.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillRepository _skillRepository;

        public SkillController(MVC_Context context, ISkillRepository skillRepository) 
        {
            _skillRepository = skillRepository;
        }

        public async Task<IActionResult> Index() //Controller
        {
            IEnumerable<Skill> skills = await _skillRepository.GetAll(); ; //Model
            return View(skills); //view
        }

        [HttpPost]
        public async Task<IActionResult> Add(Skill skill)
        {
            _skillRepository.Add(skill);
            return RedirectToAction ("Index");
        }

        public IActionResult Empty()
        {
            return View("Empty");    
        }

        public IActionResult GoToCreate()
        {
            return View("Create");    
        }

        public async Task<IActionResult> Edit(int id)
        {
            Skill skill = await _skillRepository.GetByIdAsync(id);
            return View(skill);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Skill skill = await _skillRepository.GetByIdAsync(id);
            _skillRepository.Delete(skill);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Save(int id, Skill newSkill)
        {
            Skill skill = await _skillRepository.GetByIdAsync(id);

            var name = newSkill.Name;
            var number = newSkill.SkillLevel;

            skill.SkillLevel = number;
            skill.Name = name;
            _skillRepository.Save();

            return RedirectToAction("Index");
        }
    }
}
