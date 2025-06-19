using TestTask.DataAccess.Entities;

namespace TestTask.Application.ServicesAbstraction;

public interface IUserTypeRepositoryValidationService
{
    Task<int> AddTypeAsync(UserType user);
    Task UpdateTypeAsync(UserType newUser);
    Task DeleteTypeAsync(int id);
    Task<UserType> GetTypeByIdAsync(int id);
    Task<IEnumerable<UserType>> GetTypesAsync();
}