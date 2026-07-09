using System.Diagnostics;
using Crud.Models;
using Crud.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Student std, IFormFile image)
        {
            if(image != null && image.Length > 0) {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                std.Image = fileName;
            }

            _context.Students.Add(std);
            _context.SaveChanges();
            return RedirectToAction("Show");
        }

        public IActionResult Show()
        {
            var student = _context.Students.ToList();
            return View(student);
        }

        public IActionResult Update(int id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student std, IFormFile image)
        {
            var existingImage = _context.Students.AsNoTracking().FirstOrDefault(s => s.Id == std.Id)?.Image;

            if (image != null && image.Length > 0)
            {
                if (existingImage == null)
                {
                    return NotFound();
                } 
                
                if(!string.IsNullOrEmpty(existingImage))
                {
                    if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", existingImage))) { 
                        System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", existingImage));
                    }
                }

                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                std.Image = fileName;
            }
            else
            {
                std.Image = existingImage;
            }

            //_context.Students.Update(std);
            _context.Entry(std).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Show");
        }

        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);

            if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", student!.Image!)))
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", student!.Image!));
            }

            _context.Students.Remove(student!);
            _context.SaveChanges();
            return RedirectToAction("Show");
        }
    }
}
