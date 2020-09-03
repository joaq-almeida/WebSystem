using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSystem.Repository.Contracts;
using WebSystem.Services.Contracts;

namespace WebSystem.Services
{
    public class TicketService: ITicketService
    {
        private readonly ITicketRepository _context;

        public TicketService(ITicketRepository context)
        {
            _context = context;
        }
    }
}
