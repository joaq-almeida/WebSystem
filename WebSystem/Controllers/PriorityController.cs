using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSystem.Models;
using WebSystem.Repository.Contracts;
using Microsoft.AspNetCore.Identity;

namespace WebSystem.Controllers
{
    public class PriorityController : Controller
    {
        private readonly IPriorityRepository _priority;
        private readonly UserManager<IdentityUser> _userManager;

        public PriorityController(IPriorityRepository category, UserManager<IdentityUser> userManager)
        {
            _priority = category;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var priorities = _priority.GetAll();
            if (priorities != null)
                return View(priorities);
            else
                return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Priority priority)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                priority.CreatedById = userId;
                priority.ModifiedById = userId;
                _priority.Add(priority);
                return RedirectToAction("Index", "Priority");
            }

            return View(priority);
        }

        public IActionResult Update(int id)
        {
            var priority = _priority.GetByID(id);
            return View(priority);
        }

        [HttpPost]
        public IActionResult Update(Priority priority)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                priority.ModifiedById = userId;
                _priority.Update(priority);
                RedirectToAction("Index", "Priority");
            }

            return View(priority);
        }

        public IActionResult Delete(int id)
        {
            _priority.Delete(id);
            return RedirectToAction("Index", "Priority");
        }
    }
}