using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSystem.Repository.Contracts;
using WebSystem.Models;

namespace WebSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _category;

        public CategoryController(ICategoryRepository category)
        {
            _category = category;
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
                _category.Add(category);
                return RedirectToAction("Category", "Index");
            }

            return View(category);
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                _category.Update(category);
                RedirectToAction("Category", "Index");
            }

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            _category.Delete(id);
            return RedirectToAction("Category", "Index");
        }
    }
}