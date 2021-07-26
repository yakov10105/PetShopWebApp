using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetShop.Shared.Models;
using PetShop.Testing.ControllersTesting;
using PetShopWebApp.Controllers;
using System.Collections.Generic;

namespace PetShop.Testing
{
    [TestClass]
    public class HomeControllerTestClass
    {
        [TestMethod]
        public void Index_Model_Test()
        {
            var fakeRepo = new FakeRepositoryClass();
            var homeController = new HomeController(fakeRepo);

            var res = homeController.Index() as ViewResult;

            Assert.AreEqual(typeof(List<Animal>), res.Model.GetType());
        }
    }
}
