using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSystem.Repository.Contracts;
using WebSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace WebSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _category;
        private readonly UserManager<IdentityUser>  _userManager;
        public CategoryController(ICategoryRepository category, UserManager<IdentityUser> userManager)
        {
            _category = category;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var categories = _category.GetAll();
            if (categories != null)
                return View(categories);
            else
                return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                category.CreatedById = userId;
                category.ModifiedById = userId;
                _category.Add(category);
                return RedirectToAction("Index", "Category");
            }

            return View(category);
        }

        public IActionResult Update(int id)
        {
            var category = _category.GetByID(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                category.ModifiedById = userId;
                _category.Update(category);
                return RedirectToAction("Index", "Category");
            }

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            _category.Delete(id);
            return RedirectToAction("Index", "Category");
        }
    }
}