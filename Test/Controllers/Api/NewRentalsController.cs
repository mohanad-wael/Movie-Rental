﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.Dtos;
using System.Data.Entity;
using Test.Models;

namespace Test.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
             _context = new ApplicationDbContext();
        }

       

        [HttpPost]
        public IHttpActionResult CreateRentals(NewRentalDto newRental)
        {
            
            var customer = _context.Customers.Single(m => m.Id == newRental.CustomerId);
            
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable==0)
                {
                    return BadRequest("movie is not available");

                }

                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);

            }

            _context.SaveChanges();

            return Ok();

        }
    }
}
