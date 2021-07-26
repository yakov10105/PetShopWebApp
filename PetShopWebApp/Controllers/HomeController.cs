using Microsoft.AspNetCore.Mvc;
using PetShop.Backend.Repositories;
using PetShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPetShopRepository _repo;
        public HomeController(IPetShopRepository repo)
        {
            _repo = repo;
        }
        /// <summary>
        /// Returns view with the two most commented animals in the database
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var ansToShow = _repo.GetAllAnimals()
                .OrderByDescending(a => a.Comments.ToList().Count)
                .ToList()
                .Take(2)
                .ToList();
            return View(ansToShow);
        }
    }
}
