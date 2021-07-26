using PetShop.Backend.Lib.Data;
using PetShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PetShop.Backend.Repositories
{
    public class PetShopRepository : IPetShopRepository
    {
        private readonly PetShopDbContext _context;

        public PetShopRepository(PetShopDbContext dbContext)
        {
            _context = dbContext;
        }

        public bool AddAnimal(Animal animal)
        {
            try
            {
                _context.Animals.Add(animal);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool RemoveAnimal(int animalId)
        {
            try
            {
                _context.Animals.Remove(_context.Animals.FirstOrDefault(a => a.AnimalId == animalId));
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Animal> GetAllAnimals()
        {
            return _context.Animals.ToList();
        }

        public bool UpdateAnimal( Animal animal)
        {
            try
            {
                _context.Animals.Update(animal);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }



        public bool AddCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public bool RemoveCategory(int categoryId)
        {
            try
            {
                _context.Animals
                    .Where(a => a.CategoryId == categoryId)
                    .ToList()
                    .ForEach(a => _context.Animals.Remove(a));

                _context.Categories.Remove(_context.Categories.FirstOrDefault(c => c.CategoryId == categoryId));

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }



        public bool AddComment(Comment comment)
        {
            try
            {
                _context.Animals
                   .FirstOrDefault(a => a.AnimalId == comment.AnimalId)
                   .Comments
                   .ToList()
                   .Add(comment);
                _context.Comments.Add(comment);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments.AsEnumerable();
        }

        public bool RemoveComment(int commentId)
        {
            try
            {
                _context.Comments.Remove(_context.Comments.FirstOrDefault(c => c.CommentId == commentId));
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
