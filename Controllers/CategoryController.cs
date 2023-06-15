using Azure;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Nimap_project.Data;
using Nimap_project.Models;
using System.Buffers.Text;
using System.Drawing;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System;

namespace Nimap_project.Controllers
{
    public class CategoryController : Controller
    {
       private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
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
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        

       
        
    }
}
