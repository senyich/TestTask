using TestTask.Application.ServicesAbstraction;
using TestTask.DataAccess.Entities;
using TestTask.DataAccess.RepositoriesAbstraction;

namespace TestTask.Application.Services;

public class UserTypeRepositoryValidationService : IUserTypeRepositoryValidationService
{
    private IUserTypeRepository  _userTypeRepository;

    public UserTypeRepositoryValidationService(IUserTypeRepository userTypeRepository)
    {
        _userTypeRepository = userTypeRepository;
    }
    public async Task<int> AddTypeAsync(UserType type)
    {
        try
        {
            var id = await _userTypeRepository.AddAsync(type);
            return id;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при добавлении типа пользователя: {ex.Message}");
        }
    }
    public async Task UpdateTypeAsync(UserType newType)
    {
        try
        {
            await _userTypeRepository.UpdateAsync(newType);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при обновлении типа пользователя: {ex.Message}");
        }
    }
    public async Task DeleteTypeAsync(int id)
    {
        try
        {
            await _userTypeRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при удалении типа пользователя: {ex.Message}");
        }
    }
    public async Task<UserType> GetTypeByIdAsync(int id)
    {
        try
        {
            var type = await _userTypeRepository.GetAsync(id);
            return type;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при получении типа по id: {ex.Message}");
        }
    }
    public async Task<IEnumerable<UserType>> GetTypesAsync()
    {
        try
        {
            var types = await _userTypeRepository.GetAllAsync();
            return types;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при получении всех типов пользователей: {ex.Message}");
        }
    }
}