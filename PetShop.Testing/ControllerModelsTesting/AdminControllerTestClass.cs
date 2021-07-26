using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetShop.Shared.Models;
using PetShop.Testing.ControllerModelsTesting.Fake_Web_Host;
using PetShopWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Testing.ControllersTesting
{
    [TestClass]
    public class AdminControllerTestClass
    {
        private readonly FakeWebHostEnvironment _env = new FakeWebHostEnvironment();
        [TestMethod]
        public void IndexAction_Model_Test()
        {
            var fakeRepo = new FakeRepositoryClass();
            var adminController = new AdminController(fakeRepo,_env);

            var res = adminController.Index() as ViewResult;

            Assert.AreEqual(typeof(List<Animal>), res.Model.GetType());
        }
        [TestMethod]
        public void EditAction_Model_Test()
        {
            var fakeRepo = new FakeRepositoryClass();
            var adminController = new AdminController(fakeRepo, _env);

            var res = adminController.Edit(1) as ViewResult;

            Assert.AreEqual(typeof(Animal), res.Model.GetType());
        }
        [TestMethod]
        public void AddAction_ViewBagInstance_Test()
        {
            var fakeRepo = new FakeRepositoryClass();
            var adminController = new AdminController(fakeRepo, _env);
            adminController.Add();
            var viewBag_Categories = adminController.ViewBag.Categories;

            Assert.IsInstanceOfType(viewBag_Categories, typeof(List<SelectListItem>));
        }

    }
}
