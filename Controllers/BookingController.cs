using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieBooking.Models;

namespace MovieBooking.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _db;

        public BookingController(AppDbContext db)
        {
            _db = db;
        }
        // GET: BookingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingController/Create
        public ActionResult Create(int id)
        {


            MovieDetails movie = _db.MovieDetails.FirstOrDefault(x => x.MovieId == id);
            ViewBag.Title = movie.Title;
            ViewBag.id = movie.MovieId;
            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(string title)
        {
            try
            {
                MovieDetails movie = _db.MovieDetails.FirstOrDefault(x => x.Title == title);
                Show s = _db.Shows.FirstOrDefault(x => x.MovieId == movie.MovieId);
                Booking b = new Booking()
                {
                    ShowId = s.Id
                };
                 _db.Add(b);
                _db.SaveChanges();
                return RedirectToAction("Index", "Movie");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingController/Edit/5
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

        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingController/Delete/5
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
