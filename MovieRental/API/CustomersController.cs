using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRental.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // Get  /api/Customer

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        // Get  /api/Customers/id
        
      
        public Customer GetCustomerById(int? id)
        {
            return _context.Customers.SingleOrDefault(c => c.Id == id);
        }
        [HttpPost]
        public  IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                BadRequest();
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }
        [HttpPut]
        public void UpdateCustomer(int id,Customer customer)
        { 
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var CustomerIndb = _context.Customers.SingleOrDefault(c => c.Id==id);
            if (CustomerIndb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            CustomerIndb.Name = customer.Name;
            CustomerIndb.Date = customer.Date;
            CustomerIndb.IsSubscribeTypeNewsLetter = customer.IsSubscribeTypeNewsLetter;
            CustomerIndb.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();

        }
        [HttpDelete]
        public void DeleteCustomer(int? id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var CustomerIndb = _context.Customers.SingleOrDefault(c => c.Id == id);
            _context.Customers.Remove(CustomerIndb);
            _context.SaveChanges();
        }
    }
}
