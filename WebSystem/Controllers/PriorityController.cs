using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSystem.Models;
using WebSystem.Repository.Contracts;

namespace WebSystem.Controllers
{
    public class PriorityController : Controller
    {
        private readonly IPriorityRepository _priority;

        public PriorityController(IPriorityRepository category)
        {
            _priority = category;
        }

        public IActionResult Index()
        {
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
                _priority.Add(priority);
                return RedirectToAction("Priority", "Index");
            }

            return View(priority);
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Priority priority)
        {
            if (ModelState.IsValid)
            {
                _priority.Update(priority);
                RedirectToAction("Priority", "Index");
            }

            return View(priority);
        }

        public IActionResult Delete(int id)
        {
            _priority.Delete(id);
            return RedirectToAction("Priority", "Index");
        }
    }
}