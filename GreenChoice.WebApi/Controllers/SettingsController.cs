using GreenChoice.Application.Services;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.WebApi.CustomControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace GreenChoice.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SettingsController : CustomBaseController
{
    #region Fields
    private readonly ISettingsService _settingsService;
    #endregion

    #region Ctor
    public SettingsController(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }
    #endregion

    #region Methods
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var settings = await _settingsService.GetAll(request);

        return CreateActionResultInstance(settings);
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var setting = await _settingsService.GetById(id);

        return CreateActionResultInstance(setting);
    }

    [HttpGet("[action]/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var setting = await _settingsService.GetByName(name);

        return CreateActionResultInstance(setting);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(Settings model)
    {
        await _settingsService.Create(model);
        return Ok(model);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(Settings model)
    {
        await _settingsService.Update(model);
        return Ok();
    }

    [HttpDelete("(id)")]
    public async Task<IActionResult> Remove(int id)
    {
        await _settingsService.Remove(id);
        return Ok();
    }
    #endregion
}
