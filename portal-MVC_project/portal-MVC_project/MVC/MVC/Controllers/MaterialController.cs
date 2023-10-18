using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Interface;
using MVC.Models;
using MVC.Repository;

namespace MVC.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialController(MVC_Context context, IMaterialRepository materialRepository) 
        {
            _materialRepository = materialRepository;
        } 

        public async Task<IActionResult> Index()
        {
            IEnumerable<Material> materials = await _materialRepository.GetAll();
            if (ModelState.IsValid)
            {
                return View(materials);
            }

            else 
            {
                return RedirectToAction("Empty");    
            }
        }

        public IActionResult Empty()
        {
            return RedirectToAction("Add");    
        }

        public IActionResult Create(string type)
        {
            if (type == "ElectronicCopies")
            {
                return View("CreateElectronicCopy");
            }
            if(type == "OnlineArticle")
            {
                return View("CreateOnlineArticle"); 
            }
            if (type == "VideoMaterial")
            {
                return View("CreateVideoMaterial");
            }

            return View(Index);
        }

     

        public async Task<IActionResult> Add(Material material)
        {
            _materialRepository.Add(material);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Material material = await _materialRepository.GetBeyIdAsync(id);
            return View(material);    
        }

        public async Task<IActionResult> Delete()
        {
            return RedirectToAction("Detail");
        }

        public async Task<IActionResult> Update(int id)
        {
            _materialRepository.Save();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Material material = await _materialRepository.GetBeyIdAsync(id);
            return View(material);
        }


        public async Task<IActionResult> Save(int id, Material newMaterial)
        {
            Material material = await _materialRepository.GetBeyIdAsync(id);

            var name = newMaterial.Name;
            var aouthor = newMaterial.Author;
            var numberOfpages = newMaterial.NumberOgpages;
            var format = newMaterial.Format;    
            var yearOfPublication = newMaterial.YearOfPublication;
            var dateOfPublication = newMaterial.DateOfPublication;
            var typeOfDataCarrier = newMaterial.TypeOfDatacarrier;
            var duration = newMaterial.Duration;
            var Quality = newMaterial.Quality;

            material.Name = name;
            material.Author = aouthor;
            material.NumberOgpages = numberOfpages;
            material.Format = format;
            material.YearOfPublication = yearOfPublication;
            material.DateOfPublication = dateOfPublication; 
            material.TypeOfDatacarrier = typeOfDataCarrier;
            material.Duration = duration;   
            material.Quality = Quality;
            _materialRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
