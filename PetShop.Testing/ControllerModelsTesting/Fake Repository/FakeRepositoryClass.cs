using PetShop.Backend.Repositories;
using PetShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Testing.ControllersTesting
{
    public class FakeRepositoryClass : IPetShopRepository
    {
        private readonly List<Animal> _animals;
        private readonly List<Category> _categories;

        public FakeRepositoryClass()
        {
            _animals = new List<Animal>() { new Animal() {AnimalId=1, Comments=new List<Comment>()}, new Animal() { Comments = new List<Comment>() }, new Animal() { Comments = new List<Comment>() } };
            _categories = new List<Category>() { new Category() {CategoryId=1, Animals=new List<Animal>()}, new Category() { Animals = new List<Animal>() }, new Category() { Animals = new List<Animal>() } };
        }



        public bool AddAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public bool AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public bool AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public List<Animal> GetAllAnimals()
        {
            return _animals;
        }

        public List<Category> GetAllCategories()
        {
            return _categories;
        }

        public IEnumerable<Comment> GetAllComments()
        {
            throw new NotImplementedException();
        }

        public bool RemoveAnimal(int animalId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveComment(int commentId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
