using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSystem.Models;

namespace WebSystem.Repository.Contracts
{
    public interface ITicketRepository
    {
        void Add(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(int id);
        List<Ticket> GetAll();
        Ticket GetByID(int id);
    }
}
