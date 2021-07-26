using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShop.Backend.Repositories;
using PetShop.Shared.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PetShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPetShopRepository _repo;
        private readonly IWebHostEnvironment _env;
        private readonly List<Category> _categories;
        public AdminController(IPetShopRepository repo,IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
            _categories = _repo.GetAllCategories();
        }
        /// <summary>
        /// returns view with all the animals
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.Categories = _categories;
            var animals = _repo.GetAllAnimals();
            return View(animals);
        }
        /// <summary>
        /// returns view with all the animal of the chosen category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public IActionResult Category(int categoryId)
        {
            var relevantAnimals = _categories.
               FirstOrDefault(c => c.CategoryId == categoryId)
               .Animals.ToList();
            ViewBag.Categories = _categories;
            return View("Index", relevantAnimals);
        }

        /// <summary>
        /// returns form to edit exist animal
        /// </summary>
        /// <param name="animalId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int animalId)
        {
            var animal = _repo.GetAllAnimals().FirstOrDefault(a => a.AnimalId == animalId);
            ViewBag.Animal = animal;
            return View(animal);
        }

        /// <summary>
        /// post method to edit action , checks the model validity and updates it in database
        /// </summary>
        /// <param name="newAnimal"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(Animal newAnimal)
        {
            if(ModelState.IsValid)
            {
                CheckImageFile(newAnimal);
                _repo.UpdateAnimal(newAnimal);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Delete the animal with the given id.
        /// </summary>
        /// <param name="animalId"></param>
        /// <returns></returns>
        public IActionResult Delete(int animalId)
        {
            _repo.RemoveAnimal(animalId);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// returns form to add new animal to the store
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add()
        {
            var categories = _repo.GetAllCategories().AsEnumerable();
            var selectList = new List<SelectListItem>();
            foreach (var cat in categories)
            {
                selectList.Add(new SelectListItem { Text = cat.CategoryName, Value = cat.CategoryId.ToString() });
            }
            ViewBag.Categories = selectList;
            return View();
        }

        /// <summary>
        /// post method to the add action , checks the model validity and adds it to the database
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(Animal animal)
        {
            if (ModelState.IsValid)
            {
                CheckImageFile(animal);
                _repo.AddAnimal(animal);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Add");
        }

        /// <summary>
        /// Checks if the user uploaded image , adds it to the img folder and gives the animal its picture name
        /// </summary>
        /// <param name="animal"></param>
        public void CheckImageFile(Animal animal)
        {
            if (animal.PictureFile != null)
            {
                var folder = @"\Assets\AnimalImgs\";
                var serverFolder = _env.WebRootPath + folder;
                if (!Directory.Exists(serverFolder))
                {
                    Directory.CreateDirectory(serverFolder);
                }

                var fileName = Path.GetFileName(animal.PictureFile.FileName);
                string fullPath = serverFolder + fileName;

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    animal.PictureFile.CopyTo(fileStream);
                }
                animal.PictureName = "/Assets/AnimalImgs/" + fileName;
            }
        }

    }
}
