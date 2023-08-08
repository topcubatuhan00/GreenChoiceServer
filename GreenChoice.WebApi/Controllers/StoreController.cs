using GreenChoice.Application.Services;
using GreenChoice.Domain.Models.CommentModels;
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
    #endregion

    #region Ctor
    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
    }
    #endregion

    #region List
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var categories = await _storeService.GetAll(request);

        return CreateActionResultInstance(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _storeService.GetById(id);

        return CreateActionResultInstance(category);
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
    [HttpDelete("(id)")]
    public async Task<IActionResult> Remove(int id)
    {
        await _storeService.Remove(id);
        return Ok();
    }
    #endregion
}
