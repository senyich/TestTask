using Microsoft.AspNetCore.Mvc;
using TestTask.Application.DTOs.UserType;
using TestTask.Application.DTOs.UserType.Requests;
using TestTask.Application.DTOs.UserType.Responces;
using TestTask.Application.Mapping.Abstraction;
using TestTask.Application.ServicesAbstraction;

namespace TestTask.API.Controllers;

[Route("api/users")]
public class UsersTypeController : Controller
{
    private IUserTypeRepositoryValidationService _userTypeDbValidator;
    private IUserTypeMapper _userTypeMapper;

    public UsersTypeController(
        IUserTypeMapper userTypeMapper,
        IUserTypeRepositoryValidationService userTypeDbValidator)
    {
        _userTypeMapper = userTypeMapper;
        _userTypeDbValidator = userTypeDbValidator;
    }
    [HttpGet]
    [Route("get-type/{id}")]
    public async Task<ActionResult<UserTypeResponceDto>> GetTypeAsync(int id)
    {
        try
        {
            var type = await _userTypeDbValidator.GetTypeByIdAsync(id);
            return _userTypeMapper.MapToResponce(type);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet]
    [Route("get-all-types")]
    public async Task<ActionResult<IEnumerable<UserTypeResponceDto>>> GetAllTypesAsync()
    {
        try
        {
            var types = await _userTypeDbValidator.GetTypesAsync();
            return types.Select(t => _userTypeMapper.MapToResponce(t)).ToList();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPost]
    [Route("add-type")]
    public async Task<ActionResult<AddUserTypeResponceDto>> AddUserTypeAsync(UserTypeRequestDto typeRequest)
    {
        try
        {
            typeRequest.Id = null;
            var entity = _userTypeMapper.MapToEntity(typeRequest);
            var id = await _userTypeDbValidator.AddTypeAsync(entity);
            return Ok(new AddUserTypeResponceDto{Id = id});
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPut]
    [Route("update-type")]
    public async Task<ActionResult> UpdateUserTypeAsync(UserTypeRequestDto typeRequest)
    {
        try
        {
            if(typeRequest.Id == null)
                return BadRequest("Вы передали некорректный Id");
            var entity = _userTypeMapper.MapToEntity(typeRequest);
            await _userTypeDbValidator.UpdateTypeAsync(entity);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpDelete]
    [Route("delete-type")]
    public async Task<ActionResult> DeleteUserTypeAsync(int id)
    {
        try
        {
            await _userTypeDbValidator.DeleteTypeAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}