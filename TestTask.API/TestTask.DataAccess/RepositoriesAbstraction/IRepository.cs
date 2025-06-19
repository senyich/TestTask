using TestTask.DataAccess.Entities;

namespace TestTask.DataAccess.RepositoriesAbstraction;

public interface IRepository<T> where T : BaseEntity
{
    Task<int> AddAsync(T entity);
    Task UpdateAsync(T newEntity);
    Task DeleteAsync(int id);
    Task<T> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
}