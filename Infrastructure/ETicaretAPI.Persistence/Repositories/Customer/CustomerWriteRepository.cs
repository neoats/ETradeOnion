using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Persistence.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>,ICustomerWriteRepository
    {//When dependency injection is done, we will call it with interface
        public CustomerWriteRepository(ETicaretUygulamasiDbContext context) : base(context)
        {
        }
    }
}
