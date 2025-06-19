using TestTask.Application.DTOs;
using TestTask.Application.DTOs.User.Requests;
using TestTask.Application.DTOs.User.Responces;
using TestTask.DataAccess.Entities;

namespace TestTask.Application.Mapping.Abstraction;

public interface IUserMapper : IMapper<UserResponceDto, User>
{
    User MapToEntity(UserRequestDto userResponceRequestDto);
}