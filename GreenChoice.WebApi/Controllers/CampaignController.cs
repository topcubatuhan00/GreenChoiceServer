using GreenChoice.Application.Services;
using GreenChoice.Domain.Models.CampaignModels;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.WebApi.CustomControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace GreenChoice.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CampaignController : CustomBaseController
{
    #region Fields
    private readonly ICampaignService _campaignService;
    #endregion

    #region Ctor
    public CampaignController(ICampaignService campaignService)
    {
        _campaignService = campaignService;
    }
    #endregion

    #region Methods
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var users = await _campaignService.GetAll(request);

        return CreateActionResultInstance(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _campaignService.GetById(id);

        return CreateActionResultInstance(user);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCampaignModel model)
    {
        await _campaignService.Create(model);
        return Ok(model);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateCampaignModel model)
    {
        await _campaignService.Update(model);
        return Ok();
    }

    [HttpDelete("(id)")]
    public async Task<IActionResult> Remove(int id)
    {
        await _campaignService.Remove(id);
        return Ok();
    }
    #endregion
}
