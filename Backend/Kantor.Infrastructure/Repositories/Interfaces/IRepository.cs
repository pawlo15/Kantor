using Kantor.Shared.Abstraction;

namespace Kantor.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T,S> 
        where T : class, IEntity<S>
        where S : struct
    {
        Task<bool> ExistAsync(S id);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T> GetAsync(S id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(S id);
    }
}
