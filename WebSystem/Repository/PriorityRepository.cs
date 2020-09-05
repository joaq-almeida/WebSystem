using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSystem.Repository.Contracts;
using WebSystem.Infra;
using WebSystem.Models;

namespace WebSystem.Repository
{
    public class PriorityRepository : IPriorityRepository
    {
        private readonly AppDbContext _context;

        public PriorityRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Priority priority)
        {
            priority.Created = DateTime.Now;
            priority.Modified = DateTime.Now;
            _context.priorities.Add(priority);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var handler = _context.priorities.SingleOrDefault(x => x.ID == id);
            if (handler != null)
            {
                _context.priorities.Remove(handler);
                _context.SaveChanges();
            }
        }

        public List<Priority> GetAll() => _context.priorities.ToList();

        public Priority GetByID(int id) => _context.priorities.SingleOrDefault(x => x.ID == id);

        public void Update(Priority priority)
        {
            var handler = _context.priorities.SingleOrDefault(x => x.ID == priority.ID);
            if (handler != null)
            {
                handler.Name = priority.Name;
                handler.Modified = DateTime.Now;
                _context.priorities.Update(handler);
                _context.SaveChanges();
            }
        }
    }
}
