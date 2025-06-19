using TestTask.Application.ServicesAbstraction;
using TestTask.DataAccess.Entities;
using TestTask.DataAccess.RepositoriesAbstraction;

namespace TestTask.Application.Services;

public class UserRepositoryValidationService : IUserRepositoryValidationService
{
    private IUserRepository _userRepository;

    public UserRepositoryValidationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<int> AddUserAsync(User user)
    {
        try
        {
            var id = await _userRepository.AddAsync(user);
            return id;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при добавлении пользователя: {ex.Message}");
        }
    }

    public async Task UpdateUserAsync(User newUser)
    {
        try
        {
            await _userRepository.UpdateAsync(newUser);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при обновлении пользователя: {ex.Message}");
        }
    }

    public async Task DeleteUserAsync(int id)
    {
        try
        {
            await _userRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при удалении пользователя: {ex.Message}");
        }
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        try
        {
            var user = await _userRepository.GetAsync(id);
            return user;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при получении пользователя по id: {ex.Message}");
        }
    }
    public async Task<IEnumerable<User>> GetUsersByNameAsync(string name)
    {
        try
        {
            var users = await _userRepository.GetAllAsync();
            return users.Where(u => u.Name.ToLower() == name.ToLower());
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при получении пользователей по имени: {ex.Message}");
        }
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        try
        {
            var users = await _userRepository.GetAllAsync();
            return users;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при получении всех пользователей: {ex.Message}");
        }
    }
}