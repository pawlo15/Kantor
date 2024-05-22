using Kantor.Shared.Abstraction;
using Kantor.Infrastructure.Configuration;
using Kantor.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kantor.Infrastructure.Repositories
{
    public class GenericRepository<T,S> : IRepository<T,S> 
        where T : class, IEntity<S> 
        where S : struct
    {
        protected readonly DataContext _context;

        public GenericRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async virtual Task<bool> ExistAsync(S id)
            => await _context.Set<T>().AnyAsync(e => e.Id.Equals(id));

        public async virtual Task<T> GetAsync(S id)
            => await _context.Set<T>().FirstOrDefaultAsync(e => e.Id.Equals(id));

        public async virtual Task<IReadOnlyCollection<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async virtual Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async virtual Task DeleteAsync(S id)
        {
            var data = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id.Equals(id));

            if (data != null)
                _context.Set<T>().Remove(data);
        }

        public async virtual Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
