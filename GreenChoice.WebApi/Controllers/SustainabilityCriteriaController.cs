using GreenChoice.Application.Services;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.SustainabilityCriteriaModels;
using GreenChoice.WebApi.CustomControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace GreenChoice.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SustainabilityCriteriaController : CustomBaseController
{
    #region Fields
    private readonly ISustainabilityCriteriaService _sustainabilityCriteriaService;
    #endregion

    #region Ctor
    public SustainabilityCriteriaController(ISustainabilityCriteriaService sustainabilityCriteriaService)
    {
        _sustainabilityCriteriaService = sustainabilityCriteriaService;
    }
    #endregion

    #region List
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var categories = await _sustainabilityCriteriaService.GetAll(request);

        return CreateActionResultInstance(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _sustainabilityCriteriaService.GetById(id);

        return CreateActionResultInstance(category);
    }
    #endregion

    #region Create
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateSustainabilityCriteriaModel model)
    {
        await _sustainabilityCriteriaService.Create(model);
        return Ok(model);
    }
    #endregion

    #region Update
    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateSustainabilityCriteriaModel model)
    {
        await _sustainabilityCriteriaService.Update(model);
        return Ok();
    }
    #endregion

    #region Delete
    [HttpDelete("(id)")]
    public async Task<IActionResult> Remove(int id)
    {
        await _sustainabilityCriteriaService.Remove(id);
        return Ok();
    }
    #endregion
}
