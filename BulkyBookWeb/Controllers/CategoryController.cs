using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name Cannot be same as Display Order");
            }
            if (ModelState.IsValid)
            {

                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(x=>x.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(x=>x.Id==id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name Cannot be same as Display Order");
            }
            if (ModelState.IsValid)
            {

                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryToDeleteFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(x=>x.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(x=>x.Id==id);
            if (categoryToDeleteFromDb == null)
            {
                return NotFound();
            }
            return View(categoryToDeleteFromDb);
        }

        //Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            
                var obj = _db.Categories.Find(id);
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
        }
    }
}
