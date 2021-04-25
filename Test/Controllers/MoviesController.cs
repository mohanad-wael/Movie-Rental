using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Test.Models;
using Test.ViewModels;

namespace Test.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {


            return View();
        }


        public ViewResult MovieForm()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }


        //_context.Movies.Add(movie);
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
           
 

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Include(m => m.Genre).Single(c => c.Id == movie.Id);
                Mapper.Map(movie, movieInDb);
            }
            if (movie.Genre == null)
            {
                movie.Genre = _context.Genres.SingleOrDefault(G => G.Id == movie.GenreId);
            }

            if (movie.NumberAvailable==0)
            {
                var movieInStock = movie.NumberInStock;
                movie.NumberAvailable = movieInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}