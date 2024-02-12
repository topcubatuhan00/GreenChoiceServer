using GreenChoice.Application.Services;
using GreenChoice.Domain.Core;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.StoreModels;
using GreenChoice.WebApi.CustomControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace GreenChoice.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : CustomBaseController
{
    #region Fields
    private readonly IStoreService _storeService;
    private readonly ISettingsService _settingsService;
    #endregion

    #region Ctor
    public StoreController
    (
        IStoreService storeService,
        ISettingsService settingsService
    )
    {
        _storeService = storeService;
        _settingsService = settingsService;
    }
    #endregion

    #region List
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var stores = await _storeService.GetAll(request);

        return CreateActionResultInstance(stores);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllForHomePage()
    {
        var settingsStoreSize = await _settingsService.GetByName(SettingsDefaults.BestStoreHome);
        var stores = await _storeService.GetForHome(Convert.ToInt32(settingsStoreSize.Data.Value));

        return CreateActionResultInstance(stores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var store = await _storeService.GetById(id);

        return CreateActionResultInstance(store);
    }
    #endregion

    #region Create
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateStoreModel model)
    {
        await _storeService.Create(model);
        return Ok(model);
    }
    #endregion

    #region Update
    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateStoreModel model)
    {
        await _storeService.Update(model);
        return Ok();
    }
    #endregion

    #region Delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        await _storeService.Remove(id);
        return Ok();
    }
    #endregion
}
