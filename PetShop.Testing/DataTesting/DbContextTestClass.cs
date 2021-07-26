using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetShop.Backend.Lib.Data;
using PetShop.Backend.Repositories;
using PetShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Testing.DataTesting
{
    [TestClass]
    public class DbContextTestClass
    {
        private DbContextOptions<PetShopDbContext> _options;

        [TestInitialize]
        public void Init()
        {
            _options = new DbContextOptionsBuilder<PetShopDbContext>()
                .UseInMemoryDatabase(databaseName:"DbContextDatabase").Options;
        }
        [TestCleanup]
        public void CleanUp()
        {
            using var context = new PetShopDbContext(_options);
            context.Animals.RemoveRange(context.Animals);
            context.Categories.RemoveRange(context.Categories);
            context.Comments.RemoveRange(context.Comments);
            context.SaveChanges();
        }

        #region Get All
        [TestMethod]
        public void Repository_GetAllAnimals_Test()
        {
            using var context = new PetShopDbContext(_options);
                context.Animals.Add(new Animal() { AnimalId = 1, Name = "Dog" });
                context.SaveChanges();
            var repo = new PetShopRepository(context);

            var res = repo.GetAllAnimals().Count;
            Assert.AreEqual(1, res);
        }
        [TestMethod]
        public void Repository_GetAllCategories_Test()
        {
            using var context = new PetShopDbContext(_options);
                context.Categories.Add(new Category() { CategoryId = 1, CategoryName = "Mammal" });
                context.SaveChanges();
            var repo = new PetShopRepository(context);

            var res = repo.GetAllCategories().Count;
            Assert.AreEqual(1, res);
        }
        [TestMethod]
        public void Repository_GetAllComments_Test()
        {
            using var context = new PetShopDbContext(_options);
                context.Comments.Add(new Comment() { CommentId = 1, CommentInfo = "Wow" });
                context.SaveChanges();
            var repo = new PetShopRepository(context);

            var res = repo.GetAllComments().ToList().Count;
            Assert.AreEqual(1, res);
        }
        #endregion

        #region Add
        [TestMethod]
        public void Repository_AddAnimal_Test()
        {
            using var context = new PetShopDbContext(_options);
            var repo = new PetShopRepository(context);

            Assert.IsTrue(repo.AddAnimal(new Animal() { AnimalId = 1, Name = "Dog" }));
        }
        [TestMethod]
        public void Repository_AddCategory_Test()
        {
            using var context = new PetShopDbContext(_options);
            var repo = new PetShopRepository(context);

            Assert.IsTrue(repo.AddCategory(new Category() { CategoryId = 1, CategoryName = "name" }));
        }
        [TestMethod]
        public void Repository_AddComment_Test()
        {
            using var context = new PetShopDbContext(_options);
            var repo = new PetShopRepository(context);

            repo.AddAnimal(new Animal() { AnimalId=1 , Name="animal",Comments=new List<Comment>()});

            Assert.IsTrue(repo.AddComment(new Comment() { CommentId = 1, CommentInfo= "info",AnimalId=1 }));
        }
        #endregion

        #region Remove
        [TestMethod]
        public void Repository_RemoveAnimal_Test()
        {
            using var context = new PetShopDbContext(_options);
            var repo = new PetShopRepository(context);

            repo.AddAnimal(new Animal() { AnimalId = 1, Name = "Dog" });

            Assert.IsTrue(repo.RemoveAnimal(1));
        }
        [TestMethod]
        public void Repository_RemoveCategory_Test()
        {
            using var context = new PetShopDbContext(_options);
            var repo = new PetShopRepository(context);

            repo.AddCategory(new Category() { CategoryId = 1, CategoryName = "name" });

            Assert.IsTrue(repo.RemoveCategory(1));
        }
        [TestMethod]
        public void Repository_RemoveComment_Test()
        {
            using var context = new PetShopDbContext(_options);
            var repo = new PetShopRepository(context);
            repo.AddAnimal(new Animal() { AnimalId = 1, Name = "animal", Comments = new List<Comment>() });
            repo.AddComment(new Comment() { CommentId = 1, CommentInfo = "name" ,AnimalId=1});

            Assert.IsTrue(repo.RemoveComment(1));
        }
        #endregion

        #region Update
        [TestMethod]
        public void Repository_UpdateAnimal_Test()
        {
            using var context = new PetShopDbContext(_options);
            context.Animals.Add(new Animal() { AnimalId = 1, Name = "Dog", Age = 13 });
            context.SaveChanges();
            var repo = new PetShopRepository(context);

            var animal = repo.GetAllAnimals().First();
            animal.Age = 12;
            animal.Name = "Lion";

            Assert.IsTrue(repo.UpdateAnimal(animal));
        }
        #endregion
    }
}
