using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSystem.Services.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace WebSystem.Controllers
{
    public class TicketController: Controller
    {
        private readonly ITicketService _context;

        public TicketController(ITicketService context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
