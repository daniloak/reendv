using Reendv.Domain.Entities;
using System.Collections.Generic;

namespace Reendv.Domain.Repositories
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        IEnumerable<Customer> GetAll();
    }
}
