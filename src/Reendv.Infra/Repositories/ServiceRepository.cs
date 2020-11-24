using Microsoft.EntityFrameworkCore;
using Reendv.Domain.Entities;
using Reendv.Domain.Repositories;
using Reendv.Infra.Contexts;
using System.Collections.Generic;

namespace Reendv.Infra.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ReendvContext _context;
        public ServiceRepository(ReendvContext context)
        {
            _context = context;
        }

        public void Create(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public IEnumerable<Service> GetAll()
        {
            return _context.Services.AsNoTracking();
        }
    }
}
