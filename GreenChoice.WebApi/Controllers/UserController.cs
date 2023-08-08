using GreenChoice.Application.Services;
using GreenChoice.Domain.Models.CommentModels;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.UserModels;
using GreenChoice.WebApi.CustomControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace GreenChoice.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : CustomBaseController
{
    #region Fields
    private readonly IUserService _userService;
    #endregion

    #region Ctor
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    #endregion

    #region List
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var categories = await _userService.GetAll(request);

        return CreateActionResultInstance(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _userService.GetById(id);

        return CreateActionResultInstance(category);
    }
    #endregion

    #region Create
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateUserModel model)
    {
        await _userService.Create(model);
        return Ok(model);
    }
    #endregion

    #region Update
    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateUserModel model)
    {
        await _userService.Update(model);
        return Ok();
    }
    #endregion

    #region Delete
    [HttpDelete("(id)")]
    public async Task<IActionResult> Remove(int id)
    {
        await _userService.Remove(id);
        return Ok();
    }
    #endregion
}
