using GreenChoice.Application.Services;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.UserCampaignRSModels;
using GreenChoice.WebApi.CustomControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace GreenChoice.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserCampaignRSController : CustomBaseController
{
    #region Fields
    private readonly IUserCampaignRSService _userCampaignRSService;
    #endregion

    #region Ctor
    public UserCampaignRSController(IUserCampaignRSService userCampaignRSService)
    {
        _userCampaignRSService = userCampaignRSService;
    }
    #endregion

    #region List
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var categories = await _userCampaignRSService.GetAll(request);

        return CreateActionResultInstance(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _userCampaignRSService.GetById(id);

        return CreateActionResultInstance(category);
    }
    #endregion

    #region Create
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateUserCampaignRSModel model)
    {
        await _userCampaignRSService.Create(model);
        return Ok(model);
    }
    #endregion

    #region Update
    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateUserCampaignRSModel model)
    {
        await _userCampaignRSService.Update(model);
        return Ok();
    }
    #endregion

    #region Delete
    [HttpDelete("(id)")]
    public async Task<IActionResult> Remove(int id)
    {
        await _userCampaignRSService.Remove(id);
        return Ok();
    }
    #endregion
}
