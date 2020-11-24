using Microsoft.EntityFrameworkCore;
using Reendv.Domain.Entities;
using Reendv.Domain.Repositories;
using Reendv.Infra.Contexts;
using System.Collections.Generic;

namespace Reendv.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ReendvContext _context;
        public CustomerRepository(ReendvContext context)
        {
            _context = context;
        }

        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.AsNoTracking();
        }
    }
}
