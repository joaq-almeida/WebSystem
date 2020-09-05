using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSystem.Models;

namespace WebSystem.Repository.Contracts
{
    public interface IStatusRepository
    {
        void Add(Status status);
        void Update(Status status);
        void Delete(int id);
        List<Status> GetAll();
        Status GetByID(int id);
    }
}
