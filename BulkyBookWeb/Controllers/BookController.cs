using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _myDb;

        public BookController(ApplicationDbContext db)
        {
            _myDb = db;
            
        }
        public IActionResult Index()
        {
            IEnumerable<Book> bookObj = _myDb.Books.ToList();
            return View(bookObj);
        }
    }
}
