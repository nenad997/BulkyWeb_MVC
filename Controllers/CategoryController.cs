using BulkyWeb.Models;
using BulkyWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository repository;
        public CategoryController(CategoryRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var categoriesList = repository.GetAll();

            return View(categoriesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                repository.Add(category);
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");
            }
            catch (DbUpdateException ex)
            {
                TempData["error"] = "Failed to add new category";
                Debug.WriteLine(ex.Message);
                return RedirectToAction("Create", "Category");
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            Category? foundCategory = repository.FindOne(ctg  => ctg.Id == id);

            if (foundCategory == null)
            {
                return NotFound();
            }

            return View(foundCategory);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                repository.Update(category);
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index", "Category");
            }
            catch (DbUpdateException ex)
            {
                TempData["error"] = "Failed to edit category";
                Debug.WriteLine(ex.Message);
                return RedirectToAction("Edit", "Category");
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            Category? foundCategory = repository.FindOne(ctg =>ctg.Id == id);

            if (foundCategory == null)
            {
                return NotFound();
            }

            return View(foundCategory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? foundCategory = repository.FindOne(ctg =>ctg.Id == id);

            if (foundCategory == null)
            {
                return NotFound();
            }

            try
            {
                repository.Remove(foundCategory);
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index", "Category");
            }
            catch (DbUpdateException ex)
            {
                TempData["error"] = "Failed to delete category";
                Debug.WriteLine(ex.Message);
                return RedirectToAction("Delete", "Category");
            }
        }
    }
}
