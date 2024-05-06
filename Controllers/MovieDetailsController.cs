using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieBooking.Models;

namespace MovieBooking.Controllers
{
    public class MovieDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public MovieDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MovieDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieDetails.ToListAsync());
        }

        // GET: MovieDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieDetails = await _context.MovieDetails
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieDetails == null)
            {
                return NotFound();
            }

            return View(movieDetails);
        }

        // GET: MovieDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Title,Description,CreatedDate,Genre")] MovieDetails movieDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieDetails);
        }

        // GET: MovieDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieDetails = await _context.MovieDetails.FindAsync(id);
            if (movieDetails == null)
            {
                return NotFound();
            }
            return View(movieDetails);
        }

        // POST: MovieDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Title,Description,CreatedDate,Genre")] MovieDetails movieDetails)
        {
            if (id != movieDetails.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieDetailsExists(movieDetails.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movieDetails);
        }

        // GET: MovieDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieDetails = await _context.MovieDetails
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieDetails == null)
            {
                return NotFound();
            }

            return View(movieDetails);
        }

        // POST: MovieDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieDetails = await _context.MovieDetails.FindAsync(id);
            if (movieDetails != null)
            {
                _context.MovieDetails.Remove(movieDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieDetailsExists(int id)
        {
            return _context.MovieDetails.Any(e => e.MovieId == id);
        }
    }
}
