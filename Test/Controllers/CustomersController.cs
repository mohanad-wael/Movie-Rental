using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using Test.ViewModels;
using System.Data.Entity;
using AutoMapper;

namespace Test.Controllers
{
    public class CustomersController : Controller
    {
        protected ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        [Authorize]
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(m => m.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();



            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipTypes.ToList()
            };


            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Include(m => m.MembershipType).Single(c => c.Id == customer.Id);
                Mapper.Map(customer, customerInDb);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
        public ActionResult CustomerForm()
        {
            

            var viewModel = new CustomerFormViewModel
            {
                Customer =  new Customer(),
                MembershipType = _context.MembershipTypes.ToList()


            };

            return View("CustomerForm", viewModel);
        }
    }
}