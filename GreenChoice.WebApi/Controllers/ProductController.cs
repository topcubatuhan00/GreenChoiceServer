using GreenChoice.Application.Services;
using GreenChoice.Domain.Core;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.ProductModels;
using GreenChoice.WebApi.CustomControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace GreenChoice.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : CustomBaseController
{
    #region Fields
    private readonly IProductService _productService;
    private readonly ISettingsService _settingsService;
    #endregion

    #region Ctor
    public ProductController
    (
        IProductService productService,
        ISettingsService settingsService
    )
    {
        _productService = productService;
        _settingsService = settingsService;
    }
    #endregion

    #region List
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var product = await _productService.GetAll(request);

        return CreateActionResultInstance(product);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllForHomePage()
    {
        var settingsProductSize = await _settingsService.GetByName(SettingsDefaults.BestProductHome);
        var products = await _productService.GetForHome(Convert.ToInt32(settingsProductSize.Data.Value));

        return CreateActionResultInstance(products);
    }

    [HttpPost("[action]/{id}")]
    public async Task<IActionResult> UpdateScore(UpdateSustainabilityScoreModel model)
    {
        try
        {
            await _productService.UpdateScore(model);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var product = await _productService.GetById(id);

        return CreateActionResultInstance(product);
    }
    #endregion

    #region Create
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateProductModel model)
    {
        await _productService.Create(model);
        return Ok(model);
    }
    #endregion

    #region Update
    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateProductModel model)
    {
        await _productService.Update(model);
        return Ok();
    }
    #endregion

    #region Delete
    [HttpDelete("(id)")]
    public async Task<IActionResult> Remove(int id)
    {
        await _productService.Remove(id);
        return Ok();
    }
    #endregion
}
