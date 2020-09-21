using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSystem.Repository.Contracts;
using WebSystem.Infra;
using WebSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace WebSystem.Repository
{ 
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext _context;

        public StatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Status status)
        {
            status.Created = DateTime.Now;
            status.Modified = DateTime.Now;
            _context.status.Add(status);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var handler = _context.status.SingleOrDefault(x => x.ID == id);
            if (handler != null)
            {
                _context.status.Remove(handler);
                _context.SaveChanges();
            }
        }

        public List<Status> GetAll() => _context.status.Include(x => x.CreatedBy).ToList();

        public Status GetByID(int id) => _context.status.SingleOrDefault(x => x.ID == id);

        public void Update(Status status)
        {
            var handler = _context.status.SingleOrDefault(x => x.ID == status.ID);
            if (handler != null)
            {
                handler.Name = status.Name;
                handler.Modified = DateTime.Now;
                _context.status.Update(handler);
                _context.SaveChanges();
            }
        }
    }
}
