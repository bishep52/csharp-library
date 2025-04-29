using System.Diagnostics;
using DB_connect.Data;
using DB_connect.Models;
using Microsoft.AspNetCore.Mvc;

namespace DB_connect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Загрузка данных из базы данных
            var books = _context.Books.ToList();
            return View(books); // Передача данных в представление
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
