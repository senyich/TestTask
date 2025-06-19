using Microsoft.AspNetCore.Mvc;
using TestTask.Application.DTOs;
using TestTask.Application.DTOs.User.Requests;
using TestTask.Application.DTOs.User.Responces;
using TestTask.Application.DTOs.UserType;
using TestTask.Application.Mapping;
using TestTask.Application.Mapping.Abstraction;
using TestTask.Application.ServicesAbstraction;
using TestTask.DataAccess.Entities;

namespace TestTask.API.Controllers;

[Route("api/users")]
public class UsersController : Controller
{
    private IUserRepositoryValidationService _userDbValidator;
    private IUserMapper _userMapper;
    public UsersController(
        IUserRepositoryValidationService userDbValidator, 
        IUserMapper userMapper)
    {
        _userDbValidator = userDbValidator;
        _userMapper = userMapper;
    }
    [HttpGet]
    [Route("get-user/{id}")]
    public async Task<ActionResult<UserResponceDto>> GetUserAsync(int id)
    {
        try
        {
            var user = await _userDbValidator.GetUserByIdAsync(id);
            return _userMapper.Map(user);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet]
    [Route("get-all-users")]
    public async Task<ActionResult<IEnumerable<UserResponceDto>>> GetUsersAsync()
    {
        try
        {
            var user = await _userDbValidator.GetUsersAsync();
            return user.Select(u=>_userMapper.Map(u)).ToList();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet]
    [Route("get-all-users/{name}")]
    public async Task<ActionResult<IEnumerable<UserResponceDto>>> GetUsersByNameAsync(string name)
    {
        try
        {
            var user = await _userDbValidator.GetUsersByNameAsync(name);
            return user.Select(u=>_userMapper.Map(u)).ToList();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPost]
    [Route("add-user")]
    public async Task<ActionResult<AddUserResponceDto>> AddUserAsync(UserRequestDto userRequest)
    {
        try
        {
            userRequest.Id = null;
            var entity = _userMapper.MapToEntity(userRequest);
            var id = await _userDbValidator.AddUserAsync(entity);
            return Ok(new AddUserResponceDto { Id = id });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPut]
    [Route("update-user")]
    public async Task<ActionResult> UpdateUserAsync(UserRequestDto userRequest)
    {
        try
        {
            var entity = _userMapper.MapToEntity(userRequest);
            await _userDbValidator.UpdateUserAsync(entity);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpDelete]
    [Route("delete-user")]
    public async Task<ActionResult> DeleteUserAsync(int id)
    {
        try
        {
            await _userDbValidator.DeleteUserAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}