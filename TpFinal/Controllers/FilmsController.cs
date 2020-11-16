using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TpFinal.Data;
using TpFinal.Models;

namespace TpFinal.Controllers
{
    public class FilmsController : Controller
    {
        private readonly DatabaseConnection _context;
        private readonly IWebHostEnvironment env;

        public FilmsController(DatabaseConnection context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: Films
        public async Task<IActionResult> Index()
        {
            return View(await _context.Films.ToListAsync());
        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Films
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Films/Create
        public IActionResult Create()
        {

            ViewData["PeopleId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.People, "Id", "Name");
            ViewData["GenreId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Genres, "Id", "Description");

            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Outstanding,Trailer,Summary,MoviesActors,MoviesGenres")] Film film)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                    var photoFile = files[0];
                    var path = Path.Combine(env.WebRootPath, "images\\films");
                    if (photoFile.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(photoFile.FileName);

                        using (var filestream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            photoFile.CopyTo(filestream);
                            film.Photo = fileName;
                        };

                    }
                }

                _context.Add(film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            ViewData["PeopleId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.People, "Id", "Name");
            ViewData["GenreId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Genres, "Id", "Description");


            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Outstanding,Trailer,Summary,MoviesActors,MoviesGenres")] Film film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var files = HttpContext.Request.Form.Files;
                    if (files != null && files.Count > 0)
                    {
                        var photoFile = files[0];
                        var path = Path.Combine(env.WebRootPath, "images\\films");
                        if (photoFile.Length > 0)
                        {
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(photoFile.FileName);

                            using (var filestream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                            {
                                photoFile.CopyTo(filestream);
                                film.Photo = fileName;
                            };

                        }
                    }

                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.Id))
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
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Films
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Films.FindAsync(id);
            _context.Films.Remove(film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.Id == id);
        }
    }
}
