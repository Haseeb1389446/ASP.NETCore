using dotnet_crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace dotnet_crud.Controllers
{
    public class HomeController : Controller
    {
        public readonly ApplicationDbContext _Context;

        public HomeController(ApplicationDbContext context)
        {
            _Context = context;
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
        public IActionResult Insert(User user)
        {
            _Context.users.Add(user);
            _Context.SaveChanges();

            return RedirectToAction("Show");
        }

        public IActionResult Show()
        {
            var users = _Context.users.ToList();

            return View(users);
        }

        public IActionResult Update(int id)
        {
            var users = _Context.users.Find(id);

            return View(users);
        }

        [HttpPost]
        public IActionResult Update(User users)
        {
            _Context.Entry(users).State = EntityState.Modified;
            _Context.SaveChanges();

            return RedirectToAction("Show");
        }

        public IActionResult Delete(int id)
        {
            var user = _Context.users.Find(id);
            _Context.users.Remove(user!);
            _Context.SaveChanges();

            return RedirectToAction("Show");
        }
    }
}
