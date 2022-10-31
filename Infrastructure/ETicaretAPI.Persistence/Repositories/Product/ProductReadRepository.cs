using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>,IProductReadRepository
    {
        public ProductReadRepository(ETicaretUygulamasiDbContext context) : base(context)
        {
        }
    }
}
