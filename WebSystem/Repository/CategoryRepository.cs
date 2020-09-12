using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSystem.Repository.Contracts;
using WebSystem.Infra;
using WebSystem.Models;

namespace WebSystem.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            category.Created = DateTime.Now;
            category.Modified = DateTime.Now;
            _context.category.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var handler = _context.category.SingleOrDefault(x => x.ID == id);
            if (handler != null)
            {
                _context.category.Remove(handler);
                _context.SaveChanges();
            }
        }

        public List<Category> GetAll() => _context.category.ToList();

        public Category GetByID(int id) => _context.category.SingleOrDefault(x => x.ID == id);

        public void Update(Category category)
        {
            var handler = _context.category.SingleOrDefault(x => x.ID == category.ID);
            if (handler != null)
            {
                handler.Name = category.Name;
                handler.Modified = DateTime.Now;
                _context.category.Update(handler);
                _context.SaveChanges();
            }
        }
    }
}
