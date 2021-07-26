using PetShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Backend.Repositories
{
    public interface IPetShopRepository
    {
        #region Animals
        bool AddAnimal(Animal animal);
        bool RemoveAnimal(int animalId);
        bool UpdateAnimal( Animal animal);
        List<Animal> GetAllAnimals();
        #endregion

        #region Categories
        bool AddCategory(Category category);
        bool RemoveCategory(int categoryId);
        List<Category> GetAllCategories();
        #endregion

        #region Comments
        bool AddComment(Comment comment);
        bool RemoveComment(int commentId);
        IEnumerable<Comment> GetAllComments();
        #endregion
    }
}
