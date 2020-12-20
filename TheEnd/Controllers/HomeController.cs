using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheEnd.Data;
using TheEnd.Models;

namespace TheEnd.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;

        public HomeController(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Curses.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            db.Curses.Add(course);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult About()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Course course = await db.Curses.FirstOrDefaultAsync(p => p.id == id);
                if (course != null)
                    return View(course);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin, employee")]
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Course course = await db.Curses.FirstOrDefaultAsync(p => p.id == id);
                if (course != null)
                    return View(course);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin, employee")]
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Course course = await db.Curses.FirstOrDefaultAsync(p => p.id == id);
                if (course != null)
                {
                    db.Curses.Remove(course);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
