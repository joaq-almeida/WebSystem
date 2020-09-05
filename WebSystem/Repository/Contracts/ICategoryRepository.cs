using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSystem.Models;

namespace WebSystem.Repository.Contracts
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
        List<Category> GetAll();
        Category GetByID(int id);
    }
}
