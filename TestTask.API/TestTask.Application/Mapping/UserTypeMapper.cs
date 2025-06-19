using TestTask.Application.DTOs;
using TestTask.Application.DTOs.UserType;
using TestTask.Application.DTOs.UserType.Requests;
using TestTask.Application.DTOs.UserType.Responces;
using TestTask.Application.Mapping.Abstraction;
using TestTask.DataAccess.Entities;

namespace TestTask.Application.Mapping;

public class UserTypeMapper : IUserTypeMapper
{
    public UserTypeRequestDto Map(UserType obj)
    {
        return new UserTypeRequestDto() {Id = obj.Id, Name = obj.Name };
    }

    public UserType MapToEntity(UserTypeRequestDto createUserRequestDto)
    {
        var type = new UserType() { Name = createUserRequestDto.Name };
        if (createUserRequestDto.Id != null) 
            type.Id = createUserRequestDto.Id.Value;
        return type;
    }
    public UserTypeResponceDto MapToResponce(UserType entity)
    {
        var type = new UserTypeResponceDto() { Id = entity.Id, Name = entity.Name };
        return type;
    }
}