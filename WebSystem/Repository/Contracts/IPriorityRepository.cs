using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSystem.Models;

namespace WebSystem.Repository.Contracts
{
    public interface IPriorityRepository
    {
        void Add(Priority priority);
        void Update(Priority priority);
        void Delete(int id);
        List<Priority> GetAll();
        Priority GetByID(int id);
    }
}
