using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ClassLibrary1.DataAccess.Data;
using ClassLibrary1.Models;
using ClassLibrary1.DataAccess.Repoistory;
using ClassLibrary1.DataAccess.Repoistory.IRepoistory;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        //private readonly ApplicationDbContext _db;
        private readonly IUniteOfWork _db;
        public CategoryController(IUniteOfWork db) => _db = db;
        public IActionResult Index()
        {
            //List<Category> categories = _db.categories.ToList();   
            List<Category> categories = _db.category.GetAll().ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category ct)
        {
            if (ct.Name == ct.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The display order cannot be exactly match the name");
            }
            if (ModelState.IsValid)
            {
                //  _db.categories.Add(ct);
                //  _db.SaveChanges();
                _db.category.Add(ct);
                _db.save();
                TempData["success"] = "Category successfully created";
                return RedirectToAction("Index");
            }
            return View(ct);

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // Category category = _db.categories.Find(id);
            Category category = _db.category.Get(u => u.ID == id);
            if (category == null)
            {
                return NotFound();
            }
            Debug.WriteLine(category.Name); // Check the value
            Debug.WriteLine("cat cat cat"); // Check the value

            return View(category);

        }
        [HttpPost]
        public IActionResult Edit(Category category)

        {

            if (ModelState.IsValid)
            {
                //  _db.categories.Update(category);
                //   _db.SaveChanges();
                _db.category.update(category);
                _db.save();
                TempData["success"] = "Category successfully udpated";
                return RedirectToAction(nameof(Index)); // Assuming 'Index' is your action method to list categories
            }
            return View(category);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // Category category = _db.categories.Find(id);
            Category category = _db.category.Get(u => u.ID == id);
            if (category == null)
            {
                return NotFound();
            }
            Debug.WriteLine(category.Name); // Check the value
            Debug.WriteLine("cat cat cat"); // Check the value

            return View(category);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)

        {
            //  Category ? category = _db.categories.Find(id);
            Category category = _db.category.Get(u => u.ID == id);
            if (category == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                // _db.categories.Remove(category);
                //  _db.SaveChanges();
                _db.category.Delete(category);
                _db.save();
                TempData["success"] = "Category successfully deleted";
                return RedirectToAction(nameof(Index)); // Assuming 'Index' is your action method to list categories
            }
            return View(category);

        }
    }
}
