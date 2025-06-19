using TestTask.Application.DTOs;
using TestTask.Application.DTOs.User.Requests;
using TestTask.Application.DTOs.User.Responces;
using TestTask.Application.Mapping.Abstraction;
using TestTask.DataAccess.Entities;

namespace TestTask.Application.Mapping;

public class UserMapper : IUserMapper
{
    public UserResponceDto Map(User obj)
    {
        return new UserResponceDto()
        {
            Id = obj.Id,
            Name = obj.Name,
            Type = obj.Type.Name
        };
    }
    public User MapToEntity(UserRequestDto userRequestDto)
    {
        var user = new User()
        {
            Name = userRequestDto.Name,
            TypeId = userRequestDto.TypeId
        }; 
        if(userRequestDto.Id!=null)
            user.Id = userRequestDto.Id.Value;
        return user;
    }
}