using TestTask.DataAccess.Entities;

namespace TestTask.Application.ServicesAbstraction;

public interface IUserRepositoryValidationService
{
    Task<int> AddUserAsync(User user);
    Task UpdateUserAsync(User newUser);
    Task DeleteUserAsync(int id);
    Task<User> GetUserByIdAsync(int id);
    Task<IEnumerable<User>> GetUsersByNameAsync(string name);
    Task<IEnumerable<User>> GetUsersAsync();
}