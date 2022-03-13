using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Application.Repositories
{
    public interface IRepository<TEntity, TIdentity>
    {
        Task<List<TEntity>> ReadAllAsync();
        Task<TEntity> ReadByIdAsync(TIdentity Id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TIdentity entity);
    }
}
