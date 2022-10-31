using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Repositories
{
    internal class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {//When dependency injection is done, we will call it with interface


        public CustomerReadRepository(ETicaretUygulamasiDbContext context) : base(context)
        {
        }
    }
}
