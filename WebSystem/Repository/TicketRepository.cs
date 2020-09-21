using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSystem.Models;
using WebSystem.Repository.Contracts;
using WebSystem.Infra;
using Microsoft.EntityFrameworkCore;

namespace WebSystem.Repository
{
    public class TicketRepository : ITicketRepository
    {

        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Ticket ticket)
        {
            ticket.Created = DateTime.Now;
            ticket.Modified = DateTime.Now;
            _context.tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void Update(Ticket ticket)
        {
            var handler = _context.tickets.SingleOrDefault(x => x.ID == ticket.ID);
            if (handler != null)
            {
                handler.Title = ticket.Title;
                handler.Description = ticket.Description;
                handler.Category = ticket.Category;
                handler.Priority = ticket.Priority;
                handler.Status = ticket.Status;
                handler.ModifiedById = ticket.ModifiedById;
                handler.Modified = DateTime.Now;
                _context.tickets.Update(handler);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var handler = _context.tickets.SingleOrDefault(x => x.ID == id);
            if (handler != null)
            {
                _context.tickets.Remove(handler);
                _context.SaveChanges();
            }
        }

        public List<Ticket> GetAll() => _context.tickets.Include(x => x.CreatedById).ToList();

        public Ticket GetByID(int id) => _context.tickets.SingleOrDefault(x => x.ID == id);
    }
}
