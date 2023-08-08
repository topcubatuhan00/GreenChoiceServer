using GreenChoice.Application.Services;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.ProductCriteriaRSModels;
using GreenChoice.WebApi.CustomControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace GreenChoice.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductCriteriaRSController : CustomBaseController
{
    #region Fields
    private readonly IProductCriteriaRSService _productCriteriaRSService;
    #endregion

    #region Ctor
    public ProductCriteriaRSController(IProductCriteriaRSService productCriteriaRSService)
    {
        _productCriteriaRSService = productCriteriaRSService;
    }
    #endregion

    #region List
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var categories = await _productCriteriaRSService.GetAll(request);

        return CreateActionResultInstance(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _productCriteriaRSService.GetById(id);

        return CreateActionResultInstance(category);
    }
    #endregion

    #region Create
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateProductCriteriaRSModel model)
    {
        await _productCriteriaRSService.Create(model);
        return Ok(model);
    }
    #endregion

    #region Update
    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateProductCriteriaRSModel model)
    {
        await _productCriteriaRSService.Update(model);
        return Ok();
    }
    #endregion

    #region Delete
    [HttpDelete("(id)")]
    public async Task<IActionResult> Remove(int id)
    {
        await _productCriteriaRSService.Remove(id);
        return Ok();
    }
    #endregion
}
