using TestTask.Application.DTOs;
using TestTask.Application.DTOs.UserType;
using TestTask.Application.DTOs.UserType.Requests;
using TestTask.Application.DTOs.UserType.Responces;
using TestTask.DataAccess.Entities;

namespace TestTask.Application.Mapping.Abstraction;

public interface IUserTypeMapper : IMapper<UserTypeRequestDto, UserType>
{
    UserType MapToEntity(UserTypeRequestDto createUserRequestDto);
    UserTypeResponceDto MapToResponce(UserType userType);
    
}