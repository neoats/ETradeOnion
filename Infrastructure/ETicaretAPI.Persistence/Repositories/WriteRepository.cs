using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepository<T> :IWriteRepository<T> where T: BaseEntity
    {
        //We create the database commands with the constructor classes over the context object and pull them from the Ioc container.
        private readonly ETicaretUygulamasiDbContext _context;

        public WriteRepository(ETicaretUygulamasiDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();


        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> model)
        {
            await Table.AddRangeAsync(model);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry =  Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> datas)
        {
           Table.RemoveRange(datas);
           return true;
        }


        public async Task<bool> RemoveAsync(string id)
        {
           T model = await Table.FirstOrDefaultAsync(t => t.Id == Guid.Parse(id));
           return Remove(model);

        }

        public bool UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }

        public bool Update(T model)
        {
           EntityEntry entityEntry= Table.Update(model);
           return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    }
}
