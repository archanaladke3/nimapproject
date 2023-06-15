 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nimap_project.Data;
using Nimap_project.Models;

namespace Nimap_project.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;

            var products = _context.Products
                .Include(p => p.Category)
                .OrderBy(p => p.ProductId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View(product);
        }

    }
 
}
