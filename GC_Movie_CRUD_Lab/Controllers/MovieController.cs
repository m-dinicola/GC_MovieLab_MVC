using GC_Movie_CRUD_Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_Movie_CRUD_Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly MovieDBContext _context;


        public MovieController(MovieDBContext context)
        {
            _context = context;
        }

        #region Create
        //POST: api/Movie
        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                await _context.Movies.AddAsync(newMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
                //return CreatedAtAction(nameof(GetMovie), new { id = newMovie.Id }, newMovie);
                //returns 201 status code (standard for Post that creates new server resources.

            }
            return View("Error",new ErrorViewModel(newMovie.Id.ToString()+newMovie.GetHashCode()));
        }

        #endregion

        #region Read
        //GET: api/Movie
        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        public async Task<IActionResult> GetMovie(int id)
        {
            Movie movie = await _context.Movies.FindAsync(id);
            return View(movie);

        }

        #endregion

        #region Update
        //PUT: api/Movie/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, Movie updatedMovie)
        {
            if (ModelState.IsValid)
            {
                Movie movie = await _context.Movies.FindAsync(id);
                movie.Genre = updatedMovie.Genre;
                movie.Runtime = updatedMovie.Runtime;
                movie.Title = updatedMovie.Title;
                _context.Entry(movie).State = EntityState.Modified;
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Delete
        //DELETE: api/Movie/1
        public async Task<ActionResult> DeleteMovie(int id)
        {
            Movie deletedMovie = await _context.Movies.FindAsync(id);
            if (!(deletedMovie is null)) {
                _context.Movies.Remove(deletedMovie);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        #endregion
    }
}
