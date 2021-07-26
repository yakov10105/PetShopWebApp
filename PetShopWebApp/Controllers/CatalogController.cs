using Microsoft.AspNetCore.Mvc;
using PetShop.Backend.Repositories;
using PetShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopWebApp.Controllers
{
    public class CatalogController : Controller
    {
        readonly IPetShopRepository _repo;
        private readonly List<Category> _categories;

        public CatalogController(IPetShopRepository Repository)
        {
            _repo = Repository;
            _categories = _repo.GetAllCategories();
        }

        //returns view with All animals
        public IActionResult Index()
        {
            ViewBag.Categories = _categories;
            ViewBag.Animals = _repo.GetAllAnimals();
            return View();
        }
        //returns view aimals of the selcted category
        public IActionResult Category(int categoryId)
        {
            var relevantAnimals = _categories.
                FirstOrDefault(c => c.CategoryId == categoryId)
                .Animals.ToList();
            ViewBag.Categories = _categories;
            ViewBag.Animals = relevantAnimals;
            return View("Index");
        }
        //returns page with details about the selcted animal 
        public IActionResult AnimalDes(int animalId)
        {
            var animal = _repo.GetAllAnimals().FirstOrDefault(a => a.AnimalId == animalId);

            return View(animal);
        }

        //add new comment and returns the updated page of the animal
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            if ( ModelState.IsValid)
            {
                comment.Date = DateTime.Now;
                _repo.AddComment(comment);
                return RedirectToAction("AnimalDes", new { comment.AnimalId });
            }
            return RedirectToAction("AnimalDes", new { comment.AnimalId });
        }
    }
}
