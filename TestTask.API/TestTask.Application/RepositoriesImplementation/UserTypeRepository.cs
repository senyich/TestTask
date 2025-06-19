using Microsoft.EntityFrameworkCore;
using TestTask.DataAccess;
using TestTask.DataAccess.Entities;
using TestTask.DataAccess.RepositoriesAbstraction;

namespace TestTask.Application.RepositoriesImplementation;

public class UserTypeRepository : IUserTypeRepository
{
    private static SemaphoreSlim _semaphore;
    private UsersContext _db;
    public UserTypeRepository(UsersContext db)
    {
        _db = db;
        _semaphore = new SemaphoreSlim(250, 300);
    }
    public async Task<int> AddAsync(UserType entity)
    {
        await _semaphore.WaitAsync();
        try
        {
            await _db.UserTypes.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity.Id;
        }
        finally{ _semaphore.Release(); }
    }
    public async Task UpdateAsync(UserType newEntity)
    {
        await _semaphore.WaitAsync();
        try
        {
            var updatedRows = await _db.UserTypes
                .Where(u => u.Id == newEntity.Id)
                .ExecuteUpdateAsync(p
                    => p.SetProperty(u=>u.Name, newEntity.Name));
            if(updatedRows == 0)
                throw new Exception($"Не удалось обновить тип пользователя c id {newEntity.Id}, такой не существует");
        }
        finally{ _semaphore.Release(); }
    }
    public async Task DeleteAsync(int id)
    {
        await _semaphore.WaitAsync();
        try
        {
            await _db.UserTypes
                .Where(u=>u.Id == id)
                .ExecuteDeleteAsync();
        }
        finally{ _semaphore.Release(); }
    }
    public async Task<UserType> GetAsync(int id)
    {
        await _semaphore.WaitAsync();
        try
        {
            var userType = await _db.UserTypes.FirstOrDefaultAsync(u => u.Id == id);
            return userType != null ? userType : throw new Exception("Типа с таким айди не существует");
        }
        finally{ _semaphore.Release(); }
    }
    public async Task<IEnumerable<UserType>> GetAllAsync()
    {
        await _semaphore.WaitAsync();
        try
        {
            var userTypes = await _db.UserTypes.ToListAsync();
            return userTypes.Count!=0 ? userTypes : throw new Exception("Типов не найдено");
        }
        finally{ _semaphore.Release(); }
    }
}