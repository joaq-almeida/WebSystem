using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSystem.Models;
using WebSystem.Repository.Contracts;

namespace WebSystem.Controllers
{
    public class StatusController: Controller
    {
        private readonly IStatusRepository _status;

        public StatusController(IStatusRepository status)
        {
            _status = status;
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
        public IActionResult Create(Status status)
        {
            if (ModelState.IsValid)
            {
                _status.Add(status);
                return RedirectToAction("Status", "Index");
            }

            return View(status);
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Status status)
        {
            if (ModelState.IsValid)
            {
                _status.Update(status);
                RedirectToAction("Status", "Index");
            }

            return View(status);
        }

        public IActionResult Delete(int id)
        {
            _status.Delete(id);
            return RedirectToAction("Status", "Index");
        }
    }
}
