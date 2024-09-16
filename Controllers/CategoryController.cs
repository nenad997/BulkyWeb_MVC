using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            var objCategoryList = _db.Categories.ToList();

            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            //if (category.Name == (category.DispayOrder.ToString())) {
            //    ModelState.AddModelError("name", "The DIsplayOrder cannot exactly match the Name.");
            //}

            if(!ModelState.IsValid) {
                return View();
            }
            this._db.Categories.Add(category);
            this._db.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index", "Category");
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) { 
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            //if (category.Name == (category.DispayOrder.ToString())) {
            //    ModelState.AddModelError("name", "The DIsplayOrder cannot exactly match the Name.");
            //}

            if (!ModelState.IsValid)
            {
                return View();
            }
            this._db.Categories.Update(category);
            this._db.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index", "Category");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? categoryFromDb = this._db.Categories.Find(id);
            if( categoryFromDb == null)
            {
                return NotFound();
            }
            this._db.Categories.Remove(categoryFromDb);
            this._db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index", "Category");
        }
    }
}
