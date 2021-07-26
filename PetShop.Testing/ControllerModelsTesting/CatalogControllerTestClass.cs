using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetShop.Shared.Models;
using PetShopWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Testing.ControllersTesting
{
    [TestClass]
    public class CatalogControllerTestClass
    {
        [TestMethod]
        public void IndexAction_ViewBag_Test()
        {
            var fakeRepo = new FakeRepositoryClass();
            var catalogController = new CatalogController(fakeRepo);
            catalogController.Index();
            var viewBag_categories = catalogController.ViewBag.Categories;
            var viewBag_animals = catalogController.ViewBag.Animals;

            Assert.IsInstanceOfType(viewBag_categories, typeof(List<Category>));
            Assert.IsInstanceOfType(viewBag_animals, typeof(List<Animal>));
        }
        [TestMethod]
        public void CategoryAction_ViewBag_test()
        {
            var fakeRepo = new FakeRepositoryClass();
            var catalogController = new CatalogController(fakeRepo);
            catalogController.Category(1);
            var viewBag_Categories = catalogController.ViewBag.Categories;
            var viewBag_Animals = catalogController.ViewBag.Animals;

            Assert.IsInstanceOfType(viewBag_Categories, typeof(List<Category>));
            Assert.IsInstanceOfType(viewBag_Animals, typeof(List<Animal>));
        }
        [TestMethod]
        public void AnimalDesAction_Model_test()
        {
            var fakeRepo = new FakeRepositoryClass();
            var catalogController = new CatalogController(fakeRepo);

            var res = catalogController.AnimalDes(1) as ViewResult;

            Assert.AreEqual(typeof(Animal), res.Model.GetType());
        }

    }
}
