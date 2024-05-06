using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieBooking.Models;

namespace MovieBooking.Controllers
{
    public class ShowController : Controller
    {
        private readonly AppDbContext _context;

        public ShowController(AppDbContext context)
        {
            _context = context;
        }
        // GET: ShowController
        public async Task<ActionResult> Index()
        {
            var model = await _context.Shows.ToListAsync();

            return View(model);
        }

        // GET: ShowController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShowController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShowController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShowController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShowController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShowController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShowController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
