using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {   //method = Expression<Func<T,bool>>
        /* public Task<T> GetByIdAsync(string id)=> Table.Where() for markerpattern
         base entity or interface


         Where(t=> t.id ) doesn't work if we don't do where:BaseEntity
         */

        private readonly ETicaretUygulamasiDbContext _context;

        public ReadRepository(ETicaretUygulamasiDbContext context) 
            => _context = context;
        
        public DbSet<T> Table 
            => _context.Set<T>();


        public IQueryable<T> GetAll()
            => Table;


        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method) 
            => Table.Where(method);
        
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method) 
            => await Table.SingleOrDefaultAsync(method);

        public async Task<T> GetByIdAsync(string id)
            /*=> await Table.FirstOrDefaultAsync(t => t.Id == Guid.Parse(id));*/
            => await Table.FindAsync(Guid.Parse(id));
    }
}
