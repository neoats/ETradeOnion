using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T model);
        bool RemoveRange(List<T> model);
        Task<bool> RemoveAsync(string id);
        bool UpdateAsync(T model);
        Task<int> SaveAsync();
    }
}
