using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRental.ViewModel;
using System.Net.Http;

namespace MovieRental.Controllers
{
    [AllowAnonymous]
    public class CustomerController : Controller
    {
        ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customer
        //public ActionResult Index()
        //{
        //    var customers = _context.Customers.Include(c => c.MembershipType).ToList();
        //    return View(customers);
        //}
        public ActionResult Index()
        {
            IEnumerable<Customer> customers = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54770/api/");
                var responseTask = client.GetAsync("customers");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Customer>>();
                    readTask.Wait();
                    customers = readTask.Result;
                }
                else
                {
                    customers = Enumerable.Empty<Customer>();
                    ModelState.AddModelError(string.Empty, "Server error");
                }
            }
            return View(customers);
        }

        public ActionResult Details(Customer obj)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == obj.Id);
            if (customer == null)
                return HttpNotFound();
            else
                return View(customer);
        }
        [Authorize(Roles=Roles.Admin)]
        public ActionResult CustForm(Customer customer)
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipType = membershipTypes
            };
            return View(viewModel);
        }
        [Authorize]
        public ActionResult Edit(Customer obj)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == obj.Id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipTypes.ToList()
            };
            return View("CustForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipTypes.ToList()
                };
                return View("CustForm", viewModel);
            }

            if (customer.Id==0)
            _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Date = customer.Date;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribeTypeNewsLetter = customer.IsSubscribeTypeNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Delete(int ? Id)
        {
            Customer customer = _context.Customers.Find(Id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}