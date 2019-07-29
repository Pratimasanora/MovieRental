using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MovieRental.ViewModel;

namespace MovieRental.Controllers
{
    public class MovieController : Controller
    {
        ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movie
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(Movie obj)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == obj.Id);
            if (movies == null)
                return HttpNotFound();
            else
                return View(movies);
        }

        public ActionResult MovieForm(Movie movie)
        {
            var genreTypes = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genre = genreTypes
            };
            return View(viewModel);
        }

        public ActionResult Edit(Movie obj)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == obj.Id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genre = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);

        }

        [HttpPost]

        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel
                {
                    Movie = movie,
                    Genre = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.MovieName = movie.MovieName;
                movieInDb.NoInStocks = movie.NoInStocks;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.AddedDate = movie.AddedDate;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Delete(int? Id)
        {
            Movie movie = _context.Movies.Find(Id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}