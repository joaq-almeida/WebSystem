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
    public class StatusController: Controller
    {
        private readonly IStatusRepository _status;
        private readonly UserManager<IdentityUser> _userManager;

        public StatusController(IStatusRepository status, UserManager<IdentityUser> userManager)
        {
            _status = status;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var status = _status.GetAll();
            return View(status);
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
                var userId = _userManager.GetUserId(User);
                status.CreatedById = userId;
                status.ModifiedById = userId;
                _status.Add(status);
                return RedirectToAction("Index", "Status");
            }

            return View(status);
        }

        public IActionResult Update(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Status status)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                status.ModifiedById = userId;
                _status.Update(status);
                RedirectToAction("Index", "Status");
            }

            return View(status);
        }

        public IActionResult Delete(int id)
        {
            _status.Delete(id);
            return RedirectToAction("Index", "Status");
        }
    }
}
