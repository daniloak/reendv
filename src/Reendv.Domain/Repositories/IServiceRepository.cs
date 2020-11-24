using Reendv.Domain.Entities;
using System.Collections.Generic;

namespace Reendv.Domain.Repositories
{
    public interface IServiceRepository
    {
        void Create(Service service);
        IEnumerable<Service> GetAll();
    }
}
