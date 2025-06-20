using Microsoft.EntityFrameworkCore;
using TestTask.DataAccess;
using TestTask.DataAccess.Entities;
using TestTask.DataAccess.RepositoriesAbstraction;

namespace TestTask.Application.RepositoriesImplementation;

public class UserRepository : IUserRepository
{
    private static SemaphoreSlim _semaphore;
    private UsersContext _db;
    public UserRepository(UsersContext db)
    {
        _db = db;
        _semaphore = new SemaphoreSlim(250, 300);
    }
    public async Task<int> AddAsync(User entity)
    {
        await _semaphore.WaitAsync();
        try
        {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity.Id;
        }
        finally{ _semaphore.Release(); }
    }
    public async Task UpdateAsync(User newEntity)
    {
        await _semaphore.WaitAsync();
        try
        {
            var updatedRows = await _db.Users
                .Where(u=>u.Id==newEntity.Id)
                .ExecuteUpdateAsync(p
                => p.SetProperty(u=>u.Name, newEntity.Name)
                    .SetProperty(u => u.TypeId, newEntity.TypeId));
            if(updatedRows == 0)
                throw new Exception($"Не удалось обновить пользователя c id {newEntity.Id}, пользователь не найден");
        }
        finally{ _semaphore.Release(); }
    }

    public async Task DeleteAsync(int id)
    {
        await _semaphore.WaitAsync();
        try
        {
            var deletedRows = await _db.Users
                .Where(u=>u.Id == id)
                .ExecuteDeleteAsync();
            if(deletedRows == 0)
                throw new Exception($"Нет пользователя с таким id, ничего не удалено");
        }
        finally{ _semaphore.Release(); }
    }

    public async Task<User> GetAsync(int id)
    {
        await _semaphore.WaitAsync();
        try
        {
            var user = await _db.Users
                .Include(u => u.Type)
                .FirstOrDefaultAsync(u => u.Id == id);
            return user != null ? user : throw new Exception("Пользователя с таким айди не найдено");
        }
        finally{ _semaphore.Release(); }
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        await _semaphore.WaitAsync();
        try
        {
            var users = await _db.Users
                .Include(u=>u.Type)
                .ToListAsync();
            return users.Count!=0 ? users :  throw new Exception("Пользователей не найдено");
        }
        finally{ _semaphore.Release(); }
    }
}